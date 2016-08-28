namespace Munchkin

open System 
open DomainTypes
open Battle

module Game = 

    let random = new Random();
        
    let drawRandomDoorCard state =
        state.DoorCards.[random.Next state.DoorCards.Length] 

    let startFight state monster =
        if state.CurrentPlayer.Level <= monster.MinimumPlayerLevel then state
        else
        { state with 
            CurrentBattle = createBattle monster
            TurnState = TurnState.FightingMonster
            DoorCards = state.DoorCards 
                        |> List.except [DoorCard.MonsterCard monster] 
        }
        
    let handleCardDrawn card state =
        match card with
        | MonsterCard(m) -> startFight state m
        | CurseCard(c) -> { state with TurnState = TurnState.LootOrSummonMonster; DoorCards = state.DoorCards |> List.except [DoorCard.CurseCard c]; DiscardedDoorCards = DoorCard.CurseCard c :: state.DiscardedDoorCards }
        | _ -> { state with 
                    TurnState = TurnState.LootOrSummonMonster
                    CurrentPlayer = { state.CurrentPlayer with 
                                        Cards = Card.DoorCard card :: state.CurrentPlayer.Cards } }
        
    let startTurn state =
        let doorCard = drawRandomDoorCard state
        handleCardDrawn doorCard