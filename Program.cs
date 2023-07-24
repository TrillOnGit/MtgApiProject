// See https://aka.ms/new-console-template for more information

using MtgApiProject;

var cardCall = MtgApi.GetRandCard();
var cardText = MtgApi.GetText(await cardCall);

//Console.WriteLine(await cardCall);
Console.WriteLine(await cardText);