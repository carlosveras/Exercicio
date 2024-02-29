using Questao2;
using System.Net.Http.Headers;

public class Program
{
    static HttpClient client = new HttpClient();
    public static async Task Main()
    {
        #region teste
        //string teamName = "Paris Saint-Germain";
        //int year = 2013;
        //int totalGoals = getTotalScoredGoals(teamName, year);

        //Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        //teamName = "Chelsea";
        //year = 2014;
        //totalGoals = getTotalScoredGoals(teamName, year);

        //Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
        #endregion

        Console.WriteLine("Informe o Ano :");
        var qAno = Console.ReadLine();

        Console.WriteLine("Informe o Time :");
        var qTime = Console.ReadLine();

        var qEndereco = $"https://jsonmock.hackerrank.com/api/football_matches?year={qAno}&team1={qTime}";

        client.BaseAddress = new Uri(qEndereco);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        Root campeonato = new();

        HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
        if (response.IsSuccessStatusCode)
            campeonato = await response.Content.ReadAsAsync<Root>();

        List<Root> listaPartidas = new List<Root> { campeonato };

        var resultados = listaPartidas.SelectMany(root => root.data).GroupBy(datum => new { datum.year, datum.team1 })
                                      .Select(group => new
                                       {
                                           Ano = group.Key.year,
                                           Equipe = group.Key.team1,
                                           TotalGols = group.Sum(item => Convert.ToInt16(item.team1goals))
                                       });

        foreach (var item in resultados)
            Console.WriteLine($"Ano: {item.Ano}, Equipe: {item.Equipe}, Total de Gols: {item.TotalGols}");

        Console.ReadKey();
    }

    public static int getTotalScoredGoals(string team, int year)
    {

        return 0;
    }

}

