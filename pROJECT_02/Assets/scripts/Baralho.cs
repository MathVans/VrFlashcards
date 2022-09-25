using Assets.scripts;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Baralho : Deck
{

    public BancoCartas bc;
    private List<Carta> Cards;
    public int Index = 0;
    List<int> ids;

    //private List<Carta> CardsSeen;

    public Camera Camera;
    public GameObject BaralhoCover;

    // Start is called before the first frame update
    async void Start()
    {
        ///verificar as datas do banco antes
        //Count e as cartas
        var user = await GetResource();

        var cheap = user.cheaps.Find(c=>c.cheap_id == 3);

        ids = new List<int>();

        cheap.cards.ForEach(c =>
        {
            ids.Add(c.card_id);
        });

        Cards = new List<Carta>();

        for (int i = 0; i < cheap.cards.Count; i++)
        {   
            CartasDeck.Add(Instantiate(bc.FlashcardDisponivel[0], new Vector3(0, 12, 0), Quaternion.identity));
        }

        foreach (var card in CartasDeck)
        {
            Cards.Add(card.GetComponent<Carta>());

        }

        int index = 0;

        foreach (var card in Cards)
        {

            var cardDef = cheap.cards[index];
            card.id = cardDef.card_id;
            card.Canvas.worldCamera = Camera;
            card.CanvasVerso.worldCamera = Camera;
            card.Color = Color.white;

                
                card.isActiveOnScene(await UpdateAcessDateCard(card.id));
            
           
           

            card.pos = index;
            card.URL = cardDef.content_file.First().url;
            index++;
        }
    }



    // Update is called once per frame
    public async Task<bool> UpdateAcessDateCard(int cardId)
    {
        var httpClient = new HttpClient();
        HttpResponseMessage response;

        var data = new
        {
            accessed_date = DateTime.Now,
        };


        var token = "sn9KYmnsygrgPbfqgx6aDjiJ9wYPBnx4";
        var updateurl = "https://api.baserow.io/api/database/rows/table/";
        var s = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
        var content = JsonConvert.SerializeObject(data);
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), updateurl + $"98059/{cardId}/?user_field_names=true");
        request.Headers.Add("Authorization", "Token " + token);
        //client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
        request.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
        response = await httpClient.SendAsync(request);
        if (response.StatusCode != HttpStatusCode.OK)
            return false;

        return true;
    }


    public async Task<UsuarioScript.Root> GetResource()
    {

        try
        {
            using (var httpClient = new HttpClient())
            {
                var token = "sn9KYmnsygrgPbfqgx6aDjiJ9wYPBnx4";
                var link = "https://api.baserow.io/api/database/rows/table/";
                httpClient.BaseAddress = new Uri(link);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                var response = await httpClient.GetAsync("98056/1/?user_field_names=true");
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;
                var resourceJson = await response.Content.ReadAsStringAsync();
              
                var user = JsonConvert.DeserializeObject<UsuarioScript.Root>(resourceJson);
                var userId = user.user_id;

                   response = await httpClient.GetAsync($"98061/?user_field_names=true&filter_field_611428_link_row_has='{userId}'");
                   resourceJson = await response.Content.ReadAsStringAsync();
                   var cheaps = JsonConvert.DeserializeObject<Cheap.Root>(resourceJson);
                
                cheaps.results.ForEach(cheap =>
                {
                    int index = user.cheaps.FindIndex(c => c.id == cheap.cheap_id);
                    var newCheap = new Cheap.Result();
                    newCheap.id = cheap.id;
                    newCheap.cheap_id = cheap.cheap_id;
                    newCheap.created_at = cheap.created_at;
                    newCheap.Active = cheap.Active;
                    newCheap.created_date = cheap.created_date;
                    newCheap.cards = cheap.cards;
                    newCheap.name = cheap.name;

                    user.cheaps[index] = newCheap;


                });

                //Selecionando
                response = await httpClient.GetAsync($"98061/?user_field_names=true&filter_field_611428_link_row_has='{userId}'");
                int? cheapId = null; 
                user.cheaps.ForEach(cheap =>{
                    cheapId = cheap.cheap_id;
                });
                response = await httpClient.GetAsync($"98059/?user_field_names=true&filterfield_631289link_row_has='{cheapId}'");
                resourceJson = await response.Content.ReadAsStringAsync();
                var cards = JsonConvert.DeserializeObject<Card.Root>(resourceJson);

                var cheap = user.cheaps.Find(c=>c.cheap_id == cheapId);
                cards.results.ForEach(c =>
                {
                    int index = cheap.cards.FindIndex(ch=> ch.id == c.card_id);
                    var newCard = new Card.Result();
                    newCard.id = c.id;
                    newCard.card_id = c.card_id;
                    newCard.content_type = c.content_type;
                    newCard.Active = c.Active;
                    newCard.content_text = c.content_text;
                    newCard.content_file = c.content_file;
                    newCard.created_date = c.created_date;
                    newCard.accessed_date = c.accessed_date;
                    newCard.easy_factor = c.easy_factor;
                    newCard.new_access_date = c.new_access_date;
                    newCard.name = c.name;
                    cheap.cards[index] = newCard;

                });

                return user;
            }
        }
        catch (Exception e)
        {

            throw;
        }
    }
    public void LogInform(int i)
    {
        Cards[i].isActiveOnScene(false);
        try
        {
            Cards[i + 1].isActiveOnScene(true);
        }
        catch
        {

        }
        
        Debug.Log("Carta Atual: " + i);      
    }

}



