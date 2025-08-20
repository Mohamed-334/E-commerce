using BaseArchitecture.Domain.Shared.BaseEntity.Interfaces;

namespace BaseArchitecture.Domain.Shared.BaseEntity.Implementations
{
    /// <summary>
    ///   Used To Set The Initial Properties For All Entities
    ///     1) The Primary Key Properties
    ///     2) The Creation Date (The Date that the Record Created At)
    ///     2) The Modified Date (The Date that the Record Updated At)
    ///     2) The DeletedAt Date (The Date that the Record Deleted At By Soft Delete)
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? CreatorName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? ModifierName { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string? DeleterName { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
