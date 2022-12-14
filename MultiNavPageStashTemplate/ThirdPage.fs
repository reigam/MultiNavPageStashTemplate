namespace MultiNavPageStashTemplate

open MultiNavPageStashTemplate
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module ThirdPage =
    let thisPage = AppPages.names.ThirdPage
    
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
        | Close -> model, { globalModel with PoppedByBackButton = false
                                             PageStash = [AppPages.names.FirstPage] }, Cmd.none

    let view (model: Model) (globalModel: GlobalModel)  =
        ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Button("Close All", Close)
            }
        )