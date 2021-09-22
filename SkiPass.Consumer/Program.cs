using SkiPass.Provider;

Console.WriteLine("Running app with args " + string.Join("", args));
var firstName = args[0];
var lastName = args[1];
var dob = DateTime.Parse(args[2]);
var from = DateTime.Parse(args[3]);
var to = DateTime.Parse(args[4]);

var skiPassService = new SkiPassService();
var skipass = skiPassService.OrderSkiPass(firstName, lastName, dob, from, to);