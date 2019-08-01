using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_Project.models
{
    [Table("Carta")]
    public class Carta
    {
        [Column ("id")]
        [Required]
        public long id {get; set;}

        [Column ("name")]
        [Required]
        public string name {get; set;}

        [Column ("url")]
        public string url {get; set;}


        public override string ToString(){
            return $"Nome: {this.name}\nUrl: {this.url}";
        }
    }
}