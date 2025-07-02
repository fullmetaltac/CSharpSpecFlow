using System;
using WireMock;
using WireMock.Util;
using WireMock.Types;
using WireMock.Server;
using Newtonsoft.Json;
using WireMock.Settings;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using System.Collections.Generic;

class Program
{
    private const double MAIN_PRICE = 7.0;
    private const double DRINK_PRICE = 2.5;
    private const double STARTER_PRICE = 4.0;
    private const double SERVICE_CHARGE = 0.1;

    static void Main(string[] args)
    {
        var server = WireMockServer.Start(new WireMockServerSettings
        {
            Urls = [EnviromentData.EnvVar("HOST")],
            StartAdminInterface = true,
            ReadStaticMappings = false
        });

        server.Given(
            Request.Create()
                .WithPath("/api/checkout")
                .UsingPost()
        )
        .RespondWith(
            Response.Create().WithCallback(request =>
            {
                var body = request.Body;
                var orders = JsonConvert.DeserializeObject<List<OrderDC>>(body);
                double food = 0.0;
                double drinks = 0.0;

                foreach (var order in orders)
                {
                    food += order.Mains * MAIN_PRICE + order.Starters * STARTER_PRICE;

                    double drinkPrice = DRINK_PRICE;
                    if (DateTime.Parse(order.OrderTime).Hour < 19)
                        drinkPrice *= 0.7;
                    drinks += Math.Round(order.Drinks * drinkPrice, 2);
                }
                double serviceCharge = Math.Round(food * SERVICE_CHARGE, 2);

                var response = new
                {
                    Price = food + drinks,
                    ServiceCharge = serviceCharge,
                    Total = food + serviceCharge + drinks,
                };

                Console.WriteLine(response.ToString());

                return new ResponseMessage
                {
                    StatusCode = 200,
                    BodyData = new BodyData
                    {
                        BodyAsJson = response,
                        DetectedBodyType = BodyType.Json
                    },
                };
            })
        );

        Console.WriteLine($"Fake Restaurant API running at {EnviromentData.EnvVar("HOST")}");
        Console.ReadLine();
    }
}
