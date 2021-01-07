using CrudFiraBase.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudFiraBase.Services
{
    public class ContatoService
    {
        FirebaseClient firebase = new FirebaseClient("https://crudfirabase-33fae-default-rtdb.firebaseio.com/");

        public async Task AddContato(string contatoId, string nome, string email)
        {
            await firebase.Child("Contatos").PostAsync(
                new Contato()
                {
                    ContatoId = contatoId,
                    Nome = nome,
                    Email = email
                }
            );
        }

        public async Task<List<Contato>> GetContatos()
        {
            var retorno = (await firebase.Child("Contatos")
                .OnceAsync<Contato>())
                .Select(x => new Contato()
                {
                    Nome = x.Object.Nome.ToUpper(),
                    Email = x.Object.Email,
                    ContatoId = x.Key
                }).ToList();
            return retorno;
        }

        public async Task DeleteContato(string contatoId)
        {            
            await firebase.Child("Contatos").Child(contatoId.ToString()).DeleteAsync();
        }
    }
}
