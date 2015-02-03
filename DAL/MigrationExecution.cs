using System.Data.Entity.Migrations;
using DAL.Migrations;

namespace DAL
{
    public class MigrationExecution
    {
        public static void MigrateDatabaseToLatest()
        {
            var migrationConfiguration = new Configuration();
            var migrator = new DbMigrator(migrationConfiguration);

            migrator.Update();
        }
    }
}
