using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DotNet_Project.models
{
    [Table("Deck")]
    public class Deck
    {
        
        [Column("id")]
        [Required]
        public long id {get; set;}

        [ForeignKey("user_id")]
        [Required]
        public long user_id {get; set;}

        [Column("nome")]
        [Required]
        public string nome {get; set;}

        [Column("formato")]
        public string formato {get; set;}

        //Idealmente, criptografado para economizar espaço.
        [Column("Decklist")]
        public string decklist {get; set;}

        public Deck(string nome, string formato, long user_id, string decklist)
        {
            this.nome = nome;
            this.formato = formato;
            this.user_id = user_id;
            this.decklist = decklist;
        }

        public override string ToString()
        {
            return $"Deck: {this.nome}\nFormato: {this.formato}";
        }
    }    
}