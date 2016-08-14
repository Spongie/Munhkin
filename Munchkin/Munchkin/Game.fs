namespace Munchkin

open System 

type TurnState = FightingMonster | LootOrSummonMonster

type GameState = {
    TurnState : TurnState
    CurrentPlayer : Player
    Players : List<Player>
    DoorCards : List<DoorCard>
    DiscardedDoorCards : List<DoorCard>
    TreasureCards : List<TreasureCard>
    DiscardedTreasureCards : List<TreasureCard>
    MonstersFighting : List<MonsterCard>
    }

type Game() =

    let random = new Random();
        
    member this.drawRandomDoorCard state =
        state.DoorCards.[random.Next state.DoorCards.Length]

    member this.drawRandomTreasureCard (state : GameState) =
        state.TreasureCards.[random.Next state.TreasureCards.Length]

    member this.startFight (state: GameState) (monster : MonsterCard) =
        if state.CurrentPlayer.Level <= monster.MinimumPlayerLevel then state
        else
        { state with MonstersFighting =  monster :: state.MonstersFighting;  DoorCards = state.DoorCards |> List.except [monster] }
        
    member this.startTurn (state : GameState) =
        let doorCard = this.drawRandomDoorCard state
        if (doorCard :? MonsterCard) then this.startFight state (doorCard :?> MonsterCard)
        else
        { state with TurnState = TurnState.LootOrSummonMonster; DoorCards = state.DoorCards |> List.except [doorCard] }