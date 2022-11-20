﻿namespace MultiNavPageStashTemplate

open MultiNavPageStashTemplate
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module SecondPage =
    let thisPage = AppPages.names.SecondPage
    
    type Model = { 
        Title: AppPages.Name 
    }
      
    type Msg =
        | OpenPage of AppPages.Name
        | Close

    let initModel = { Title = thisPage }

    let init() = initModel, Cmd.none

    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | OpenPage s -> model, { globalModel with PageStash = List.append globalModel.PageStash [s] }, Cmd.none
        | Close -> model, { globalModel with PageStash = [AppPages.names.FirstPage] }, Cmd.none

    let view (model: Model) (globalModel: GlobalModel)  =
        ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Label("First Label")
                Button("Go To Third Page", OpenPage AppPages.names.ThirdPage)
                Button("Close All", Close)
                Label("Last Label")
            }
        )