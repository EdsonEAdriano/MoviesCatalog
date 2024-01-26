using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalog.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Movies(Title, Description,ReleaseDate, ImagePath, CategoryId) " +
                   "VALUES('The Conjuring: Last Rites', 'The Conjuring: Last Rites is the next chapter in the successful horror franchise, following the adventures of paranormal experts Ed and Lorraine Warren.', '2025-01-01', 'TheConjuring.jpg', 3)");
        
            mb.Sql("INSERT INTO Movies(Title, Description, ReleaseDate, ImagePath, CategoryId) " +
                   "VALUES('Interstellar', 'A viagem interestelar de uma equipe de exploradores em busca de um novo lar para a humanidade.', '2014-11-07', 'Interstellar.jpg', 1)");
            
            mb.Sql("INSERT INTO Movies(Title, Description, ReleaseDate, ImagePath, CategoryId) " +
                   "VALUES('Gone Girl', 'Um suspense psicológico sobre o desaparecimento misterioso de uma mulher.', '2014-10-03', 'GoneGirl.jpg', 2)");
            
            mb.Sql("INSERT INTO Movies(Title, Description, ReleaseDate, ImagePath, CategoryId) " +
                   "VALUES('Superbad', 'Duas amigos tentam fazer a festa de formatura épica antes de se formarem no ensino médio.', '2007-08-17', 'Superbad.jpg', 4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE Movies");
        }
    }
}
