namespace Opea.GestaoBiblioteca.Infrastructure.ValueObjects
{
    public static class MigrationBase
    {
        public static readonly DateTime DataBase = new(2025, 09, 06, 0, 0, 0, DateTimeKind.Utc);

        public static readonly Guid BaseId001 = new("00000000-0000-0000-0000-000000000001");
        public static readonly Guid BaseId002 = new("00000000-0000-0000-0000-000000000002");
        public static readonly Guid BaseId003 = new("00000000-0000-0000-0000-000000000003");

        public static readonly Guid BaseId004 = new("00000000-0000-0000-0000-000000000004");
        public static readonly Guid BaseId005 = new("00000000-0000-0000-0000-000000000005");
        public static readonly Guid BaseId006 = new("00000000-0000-0000-0000-000000000006");
    }
}