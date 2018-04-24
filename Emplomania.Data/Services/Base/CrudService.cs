using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services.Base
{
    public class CrudService<VOT, ENT> : ServiceBase<VOT, ENT>, ICrudService<VOT, ENT> where ENT : class
    {
        public CrudService(EmplomaniaAdminDBContext db) : base(db)
        {

        }

        protected void ResetNavigationProperties(ENT entity)
        {
            var entityType = GeElementType(typeof(ENT));
            foreach (var navProperty in entityType.NavigationProperties)
            {
                var propInfo = typeof(ENT).GetProperty(navProperty.Name);
                if (!propInfo.PropertyType.IsInterface)
                {
                    var asosiationType = navProperty.RelationshipType as AssociationType;
                    if (asosiationType != null)
                    {
                        var contrains = asosiationType.ReferentialConstraints.GetEnumerator();

                        if (contrains.MoveNext())
                        {
                            List<object> keyValues = new List<object>();
                            keyValues.Add(typeof(ENT).GetProperty(contrains.Current.ToProperties[0].Name).GetValue(entity));

                            while (contrains.MoveNext())
                            {
                                keyValues.Add(typeof(ENT).GetProperty(contrains.Current.ToProperties[0].Name).GetValue(entity));
                            }

                            var navPropValue = db.Set(propInfo.PropertyType).Find(keyValues.ToArray());
                            propInfo.SetValue(entity, navPropValue);
                        }
                    }

                    //if(contrains.MoveNext())
                    //{
                    //    var x = Expression.Parameter(propInfo.PropertyType, "x");

                    //    var constant = Expression.Constant(typeof(ENT).GetProperty(contrains.Current.Name).GetValue(entity));

                    //    //var equalExp = Expression.Equal(Expression.Property(x, devProps.Current.Name),
                    //    //    );

                    //    //while (devProps.MoveNext())
                    //    //{
                    //    //    equalExp = Expression.And(
                    //    //        equalExp,
                    //    //        Expression.Equal(
                    //    //            Expression.Property(x, devProps.Current.Name),
                    //    //            Expression.Constant(typeof(ENT).GetProperty(devProps.Current.Name).GetValue(entity))
                    //    //            )
                    //    //        );
                    //    //}

                    //    //var set = (DbSet<ENT>)(typeof(TenderContext).GetProperties().FirstOrDefault(p => p.PropertyType.IsGenericType && p.PropertyType.GenericTypeArguments.Contains(typeof(ENT))).GetValue(db));
                    //    //var navPropValue = set.FirstOrDefault(Expression.Lambda<Func<ENT, bool>>(equalExp, x));
                    //    //propInfo.SetValue(entity, navPropValue);
                    //}
                }
            }
        }

        public virtual VOT Add(VOT vo, bool saveChanges=true)
        {
            var entity = Mapper.Map<VOT, ENT>(vo);
            ResetNavigationProperties(entity);
            var res = Mapper.Map<ENT, VOT>(db.Set<ENT>().Add(entity));
            if(saveChanges)
                db.SaveChanges();

            return res;
        }

        public virtual void Delete(VOT vo)
        {
            var entity = db.Set<ENT>().FirstOrDefault(GetEntityExpression(vo));
            db.Set<ENT>().Remove(entity);
            db.SaveChanges();
        }

        public virtual void Update(VOT vo)
        {
            var entity = db.Set<ENT>().FirstOrDefault(GetEntityExpression(vo));
            Mapper.Map<VOT, ENT>(vo, entity);

            ResetNavigationProperties(entity);

            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public virtual bool Exist(VOT vo)
        {
            return db.Set<ENT>().Any(GetEntityExpression(vo));
        }

        protected void FillNullProperties(Object obj)
        {
            if (obj == null)
                return;
            var type = obj.GetType();
            foreach (var prop in type.GetProperties().Where(x => x.PropertyType.Equals(typeof(string))))
            {
                if (string.IsNullOrEmpty((string)prop.GetValue(obj)))
                    prop.SetValue(obj, "");
            }
        }

        private Expression<Func<ENT, bool>> GetEntityExpression(Dictionary<string, object> primaryKeys)
        {
            var keysEnumerator = primaryKeys.Keys.GetEnumerator();
            keysEnumerator.MoveNext();
            var x = Expression.Parameter(typeof(ENT), "x");

            var equalExp = Expression.Equal(
                Expression.Property(x, keysEnumerator.Current),
                Expression.Constant(primaryKeys[keysEnumerator.Current]));

            while (keysEnumerator.MoveNext())
            {
                equalExp = Expression.And(equalExp, Expression.Equal(
                    Expression.Property(x, keysEnumerator.Current),
                    Expression.Constant(primaryKeys[keysEnumerator.Current])));
            }

            return Expression.Lambda<Func<ENT, bool>>(equalExp, x);
        }

        private Expression<Func<ENT, bool>> GetEntityExpression(VOT vo)
        {
            var entityType = GeElementType(typeof(ENT));
            Dictionary<string, object> keys = new Dictionary<string, object>();
            foreach (var key in entityType.KeyMembers)
            {
                PropertyInfo prop = typeof(VOT).GetProperty(key.Name);
                keys[key.Name] = prop.GetValue(vo);
            }

            return GetEntityExpression(keys);
        }

        private EntityType GeElementType(Type type)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)db).ObjectContext;
            var objectSet = typeof(ObjectContext).GetMethod("CreateObjectSet", new Type[] { }).MakeGenericMethod(type).Invoke(objectContext, new object[] { });
            return (typeof(ObjectSet<>).MakeGenericType(type).GetProperty("EntitySet").GetValue(objectSet) as EntitySet).ElementType;
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public void UndoChanges()
        {
            foreach (var entry in db.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
            db.SaveChanges();
        }
    }
}
