open System

printf "Введите кол-во строк: "
let size = Console.ReadLine()
let check1 = 
    if size = "0" then
        printfn "Список пуст."
        exit 1 
    match System.Int32.TryParse(size) with
    | true, parsedInt -> parsedInt
    | false, _ -> 
        printfn "Ошибка: Введите целое число."
        exit 1 

let minL = 3
let maxL = 7

printf "Введите символ для добавления в конец: "
let symbol = Console.ReadLine()
let check2 =
    if String.IsNullOrEmpty(symbol) then
        printfn "Ошибка: Вы не ввели символ."
        exit 1
    elif symbol.Length > 1 then
        printfn "Ошибка: Введите только один символ."
        exit 1
    else
        symbol.[0]

let generateRand (count: int) (minL: int) (maxL: int) =
    let rnd = new Random()
    [ for i in 1..count do
        let stringL = rnd.Next(minL, maxL + 1)
        let stringC = 
            [ for j in 1..stringL do
                let index = rnd.Next(26) 
                char (int 'a' + index) ] 
        String(List.toArray stringC) ]

let addToList (add: char) (sList: string list) =
    List.map (fun str -> str + string add) sList

let MyList = generateRand check1 minL maxL
printfn "Исходный список:"
MyList |> List.iter (printfn "%s")

let newList = addToList check2 MyList
printfn "\nНовый список:"
newList |> List.iter (printfn "%s")
