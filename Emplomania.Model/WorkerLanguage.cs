using System;

namespace Emplomania.Model
{
    public class WorkerLanguage
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid LanguageFK { get; set; }
        public Guid LanguageLevelFK { get; set; }
    }
}