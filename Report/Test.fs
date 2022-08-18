module TestProject1

open NUnit.Framework
open SMTLIB2
open SMTLIB2.Parser

[<SetUp>]
let Setup () = ()

[<Test>]
let Test1 () =
  let test =
    [ "(define-fun c_0 () Int 0)"
      "(define-fun c_1 () Int 1)"
      "(define-fun c_2 () Int 0)"
      "(define-fun c_3 () Int 1)"
      "(define-fun c_4 () Int 0)"
      "(define-fun c_5 () Int 1)"
      "(define-fun c_6 () Int (- 1))" ]

  let p1 = Parser()

  let result =
    fun (p: Parser) ->
      List.fold (fun acc x ->
        sprintf "%s%s\n" acc
        <| (List.fold (fun acc x -> $"%s{acc}%s{x.ToString()}\n") "" (p.ParseLine x))) ""

  let first =
    test
    |> result p1

  let p2 = Parser()

  let second =
    test
    |> result p2
  
  Assert.IsTrue(first.Equals second)
