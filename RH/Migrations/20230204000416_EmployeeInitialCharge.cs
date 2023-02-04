using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeInitialCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                            "INSERT " +
                                            "INTO Employees" +
                                                "(name, email, password, salary, permission) " +
                                            "VALUES" +
                                                "('Funcionário01', 'funcionario01@senai.com.br', 'funcionario01123', 12546.00, 1)," +
                                                "('Funcionário02', 'funcionario02@senai.com.br', 'funcionario02123', 13546.00, 1)," +
                                                "('Funcionário03', 'funcionario03@senai.com.br', 'funcionario03123', 13000.00, 1)," +
                                                "('Gerente01',  'gerente01@senai.com.br','gerente01123', 23453.89, 2)," +
                                                "('Gerente02',  'gerente02@senai.com.br','gerente02123', 20453.89, 2)," +
                                                "('Gerente03',  'gerente03@senai.com.br','gerente03123', 23000.89, 2)," +
                                                "('Administrador01',  'adm01@senai.com.br','adm01123', 37453.34, 3)," +
                                                "('Administrador02',  'adm02@senai.com.br','adm02123', 38453.34, 3)," +
                                                "('Administrador03',  'adm03@senai.com.br','adm03123', 36453.34, 3)");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
