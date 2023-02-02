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
                                   "('Funcionario 01', 'funcionario01@senai.com.br', 'funcionario01123', 10546.00, 1)," +
                                   "('Funcionario 02', 'funcionario02@senai.com.br', 'funcionario02123', 15546.00, 1)," +
                                   "('Funcionario 03', 'funcionario03@senai.com.br', 'funcionario03123', 10400.00, 1)," +
                                   "('Gerente01',  'gerente01@senai.com.br','gerente01123', 25453.89, 2)," +
                                   "('Gerente02',  'gerente02@senai.com.br','gerente02123', 21222.89, 2)," +
                                   "('Gerente03',  'gerente@senai.com.br','gerente03123', 20453.89, 2)," +
                                   "('Administrador01',  'adm01@senai.com.br','adm01123', 30453.34, 3)," +
                                   "('Administrador02',  'adm02@senai.com.br','adm02123', 32456.34, 3)," +
                                   "('Administrador03',  'adm03@senai.com.br','adm03123', 36500.00, 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
