namespace AuthorizationWithPermission.API.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool IsActived { get; set; }
    }
}
