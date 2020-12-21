using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Classes
{
    public class Contato
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Email} - {Tel}";
        }
    }
}
