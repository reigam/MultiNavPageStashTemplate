﻿namespace MultiNavPageStashTemplate

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms

open type View

module FirstPage =
    let thisPage = AppPages.names.FirstPage
    
    type Model = {
        Title: AppPages.Name
    }
    
    type Msg =
        | OpenPage of AppPages.Name
        
    let initModel = {
        Title = thisPage
    }
    
    let init() = initModel, Cmd.none
    
    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | OpenPage s -> model, {globalModel with PageStash = List.append globalModel.PageStash [s]}, Cmd.none
            
    let view (model: Model) (globalModel: GlobalModel) =        
        ContentPage(
            (model.Title |> AppPages.nameValue),
            VStack() {
                Label("First Label")
                    .centerTextHorizontal()                
                Button("Go To Second Page", OpenPage AppPages.names.SecondPage)
                Label("Last Label")
                    .centerTextHorizontal()        
            }
        )       
        
 