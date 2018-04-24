using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class WorkerLanguageVO
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid LanguageFK { get; set; }
        public Guid LanguageLevelFK { get; set; }

        private LanguageVO language;
        public LanguageVO Language
        {
            get { return language; }
            set
            {
                language = value;
                if (language != null)
                    LanguageFK = language.Id;
            }
        }

        private LanguageLevelVO languageLevel;
        public LanguageLevelVO LanguageLevel
        {
            get { return languageLevel; }
            set
            {
                languageLevel = value;
                if (languageLevel != null)
                    LanguageLevelFK = languageLevel.Id;
            }
        }

    }
}
