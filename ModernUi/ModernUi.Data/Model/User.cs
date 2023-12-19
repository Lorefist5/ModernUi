using ModernUi.Data.Model.Base;
using ModernUi.Data.Repositories.Interfaces;

namespace ModernUi.Data.Model
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;


    }
}
