namespace Munchkin

open System 
open DomainTypes

module Game = 

    let random = new Random();
        
    let drawRandomDoorCard state =
        state.DoorCards.[random.Next state.DoorCards.Length]

    let startFight state monster =
        if state.CurrentPlayer.Level <= monster.MinimumPlayerLevel then state
        else
        { state with MonstersFighting =  monster :: state.MonstersFighting; TurnState = TurnState.FightingMonster;  DoorCards = state.DoorCards |> List.except [DoorCard.MonsterCard monster] }
        
    let handleCardDrawn card state =
        match card with
        | MonsterCard(m) -> startFight state m
        | CurseCard(c) -> { state with TurnState = TurnState.LootOrSummonMonster; DoorCards = state.DoorCards |> List.except [DoorCard.CurseCard c] }
    

    let startTurn state =
        let doorCard = drawRandomDoorCard state
        handleCardDrawn doorCard