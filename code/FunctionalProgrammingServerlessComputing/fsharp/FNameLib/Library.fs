namespace FNameLib

module NameParsing =
    
//    let fullNames = ["Per Hagen";"Hans Hansen";"Per Kristian Hansen";"Kristian Kristiansen";"Hans Kristian"]

//    let crappyFullNames = ["Per Hagen";"Hans Hansen";"PER-kristian Hansen";"Kristian Kristiansen";"Hans Kristian";"KnUT-PeR KRistiansen"]

    let getMostPopularNames (nameList:string seq) = 
        nameList 
        |> Seq.collect (fun fullName -> (fullName.Split ' ') |> Array.toSeq)
        |> Seq.sort
        |> Seq.countBy (fun x -> x)
        |> Seq.sortByDescending (fun (name, count) -> count)
        |> Seq.map (fun (name,count) -> name)
        |> Seq.truncate 3
    
    let getMostPopularNamesRefactored (nameList:string seq) = 
        nameList 
        |> Seq.collect (fun fullName -> fullName.Split(' ','-') |> Array.toSeq)
        |> Seq.map (fun (name:string) -> name.ToLower())
        |> Seq.sort
        |> Seq.countBy (fun x -> x)
        |> Seq.sortByDescending (fun (name, count) -> count)
        |> Seq.map (fun (name,count) -> name)
        |> Seq.truncate 3


    //Slik tester man i F# interactive feks:

    //let result = getMostPopularNames fullNames
    //let result2 = getMostPopularNamesRefactored crappyFullNames
    //printfn "%A" result;
    //printfn "%A" result2;

    //Output:

    //seq ["Kristian"; "Hans"; "Hansen"]
    //seq ["kristian"; "per"; "hans"]