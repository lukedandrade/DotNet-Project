using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNet_Project.models
{   
    
    
    [Table("usuario")]
    public class  Usuario
    {
        
        [Column("id")]
        [Required]
        public long id {get; set;}

        [Column("username")]
        [Required]
        public string username {get; set;}

        [Column("password")]
        [Required]
        public string password {get; set;}

        public Usuario(string username, string password)
        {
            this.username = username;
            this.password = password;

        }

        public override string ToString()
        {
            return $"$Jogador {username}";
        }
    }
}