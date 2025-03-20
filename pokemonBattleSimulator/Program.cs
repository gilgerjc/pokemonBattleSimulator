using pokemonBattleSimulator.PkmnObjects;

string input = @"
Pikachu @ Light Ball
Level: 50
Timid Nature
Ability: Static
- Thunderbolt
- Quick Attack
- Iron Tail
- Volt Tackle";

try
{
  Pokemon pikachu = PokemonParser.ParsePokemon(input);
  Console.WriteLine($"Name: {pikachu._Name}");
  Console.WriteLine($"Level: {pikachu._Level}");
  Console.WriteLine($"Nature: {pikachu._Nature}");
  Console.WriteLine($"Ability: {pikachu._Ability}");
  Console.WriteLine($"Moves: {string.Join(", ", pikachu._Moves)}");
}
catch (Exception ex)
{
  Console.WriteLine($"Error: {ex.Message}");
}