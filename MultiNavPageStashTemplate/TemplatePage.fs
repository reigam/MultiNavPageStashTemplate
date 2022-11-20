﻿namespace MultiNavPageStashTemplate

open MultiNavPageStashTemplate
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module TemplatePage =
    let thisPage = AppPages.names.TemplatePage
    
    type Model = { 
        Title: AppPages.Name 
    }
      
    type Msg =
        | Close

    let initModel = { Title = thisPage }

    let init() = initModel, Cmd.none

    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | Close -> model, { globalModel with PageStash = [thisPage] }, Cmd.none

    let view (model: Model) (globalModel: GlobalModel)  =
        ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Button("Do Something", Close)
            }
        )