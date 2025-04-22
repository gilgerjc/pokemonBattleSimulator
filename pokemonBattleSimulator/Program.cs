using pokemonBattleSimulator;
using pokemonBattleSimulator.PkmnObjects;
using pokemonBattleSimulator.PkmnObjects.PkmnItem;
using pokemonBattleSimulator.PkmnObjects.PkmnMove;

ItemFunctions.LoadItemDictionary();
MoveFunctions.LoadMoveDictionary();
MoveDatabase.LoadMoveCsv("C:\\Users\\jgilger\\source\\repos\\pokemonBattleSimulator\\pokemon_moves.csv");

string path = "C:\\Users\\jgilger\\source\\repos\\pokemonBattleSimulator\\battle.txt";
string battle = File.ReadAllText(path);


Field field = PkmnParser.BattleParse(battle);

Display.ShowPokemon(field._AI._ActivePkmn[0]);

Dictionary<Move, double> moveProbs = field._AI.GetMoveProbabilities(field._Player._ActivePkmn[0], field);
int s = 0;
