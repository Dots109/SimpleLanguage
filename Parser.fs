// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "./Parser.fsy"

open Language

let createTerm info termTree =
    {TermTree = termTree; TermInfo = info}

let openVar (var: Term) =
    match var.TermTree with
    | Var s -> s
    | _ -> failwith "parse error"

# 18 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | EOT of (Language.TermInfo)
  | HASHHELP of (Language.TermInfo)
  | HASHLOAD of (Language.TermInfo)
  | HASHEXIT of (Language.TermInfo)
  | LET of (Language.TermInfo)
  | REC of (Language.TermInfo)
  | IN of (Language.TermInfo)
  | EQUAL of (Language.TermInfo)
  | LESSTHAN of (Language.TermInfo)
  | GREATERTHAN of (Language.TermInfo)
  | LESSTHANEQ of (Language.TermInfo)
  | GREATERTHANEQ of (Language.TermInfo)
  | ANDAND of (Language.TermInfo)
  | PIPEPIPE of (Language.TermInfo)
  | PLUS of (Language.TermInfo)
  | MINUS of (Language.TermInfo)
  | STAR of (Language.TermInfo)
  | SLASH of (Language.TermInfo)
  | INTEGER of (int * Language.TermInfo)
  | IF of (Language.TermInfo)
  | THEN of (Language.TermInfo)
  | ELSE of (Language.TermInfo)
  | TRUE of (Language.TermInfo)
  | FALSE of (Language.TermInfo)
  | LPAREN of (Language.TermInfo)
  | RPAREN of (Language.TermInfo)
  | FUN of (Language.TermInfo)
  | RARROW of (Language.TermInfo)
  | VAR of (string * Language.TermInfo)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_EOT
    | TOKEN_HASHHELP
    | TOKEN_HASHLOAD
    | TOKEN_HASHEXIT
    | TOKEN_LET
    | TOKEN_REC
    | TOKEN_IN
    | TOKEN_EQUAL
    | TOKEN_LESSTHAN
    | TOKEN_GREATERTHAN
    | TOKEN_LESSTHANEQ
    | TOKEN_GREATERTHANEQ
    | TOKEN_ANDAND
    | TOKEN_PIPEPIPE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_STAR
    | TOKEN_SLASH
    | TOKEN_INTEGER
    | TOKEN_IF
    | TOKEN_THEN
    | TOKEN_ELSE
    | TOKEN_TRUE
    | TOKEN_FALSE
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_FUN
    | TOKEN_RARROW
    | TOKEN_VAR
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startmain
    | NONTERM_atom
    | NONTERM_applist
    | NONTERM_expr
    | NONTERM_term
    | NONTERM_toplevellet
    | NONTERM_directive
    | NONTERM_main

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | EOT _ -> 1 
  | HASHHELP _ -> 2 
  | HASHLOAD _ -> 3 
  | HASHEXIT _ -> 4 
  | LET _ -> 5 
  | REC _ -> 6 
  | IN _ -> 7 
  | EQUAL _ -> 8 
  | LESSTHAN _ -> 9 
  | GREATERTHAN _ -> 10 
  | LESSTHANEQ _ -> 11 
  | GREATERTHANEQ _ -> 12 
  | ANDAND _ -> 13 
  | PIPEPIPE _ -> 14 
  | PLUS _ -> 15 
  | MINUS _ -> 16 
  | STAR _ -> 17 
  | SLASH _ -> 18 
  | INTEGER _ -> 19 
  | IF _ -> 20 
  | THEN _ -> 21 
  | ELSE _ -> 22 
  | TRUE _ -> 23 
  | FALSE _ -> 24 
  | LPAREN _ -> 25 
  | RPAREN _ -> 26 
  | FUN _ -> 27 
  | RARROW _ -> 28 
  | VAR _ -> 29 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_EOT 
  | 2 -> TOKEN_HASHHELP 
  | 3 -> TOKEN_HASHLOAD 
  | 4 -> TOKEN_HASHEXIT 
  | 5 -> TOKEN_LET 
  | 6 -> TOKEN_REC 
  | 7 -> TOKEN_IN 
  | 8 -> TOKEN_EQUAL 
  | 9 -> TOKEN_LESSTHAN 
  | 10 -> TOKEN_GREATERTHAN 
  | 11 -> TOKEN_LESSTHANEQ 
  | 12 -> TOKEN_GREATERTHANEQ 
  | 13 -> TOKEN_ANDAND 
  | 14 -> TOKEN_PIPEPIPE 
  | 15 -> TOKEN_PLUS 
  | 16 -> TOKEN_MINUS 
  | 17 -> TOKEN_STAR 
  | 18 -> TOKEN_SLASH 
  | 19 -> TOKEN_INTEGER 
  | 20 -> TOKEN_IF 
  | 21 -> TOKEN_THEN 
  | 22 -> TOKEN_ELSE 
  | 23 -> TOKEN_TRUE 
  | 24 -> TOKEN_FALSE 
  | 25 -> TOKEN_LPAREN 
  | 26 -> TOKEN_RPAREN 
  | 27 -> TOKEN_FUN 
  | 28 -> TOKEN_RARROW 
  | 29 -> TOKEN_VAR 
  | 32 -> TOKEN_end_of_input
  | 30 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startmain 
    | 1 -> NONTERM_atom 
    | 2 -> NONTERM_atom 
    | 3 -> NONTERM_atom 
    | 4 -> NONTERM_atom 
    | 5 -> NONTERM_atom 
    | 6 -> NONTERM_applist 
    | 7 -> NONTERM_applist 
    | 8 -> NONTERM_expr 
    | 9 -> NONTERM_expr 
    | 10 -> NONTERM_expr 
    | 11 -> NONTERM_expr 
    | 12 -> NONTERM_expr 
    | 13 -> NONTERM_expr 
    | 14 -> NONTERM_expr 
    | 15 -> NONTERM_expr 
    | 16 -> NONTERM_expr 
    | 17 -> NONTERM_expr 
    | 18 -> NONTERM_expr 
    | 19 -> NONTERM_expr 
    | 20 -> NONTERM_expr 
    | 21 -> NONTERM_expr 
    | 22 -> NONTERM_term 
    | 23 -> NONTERM_term 
    | 24 -> NONTERM_term 
    | 25 -> NONTERM_term 
    | 26 -> NONTERM_term 
    | 27 -> NONTERM_toplevellet 
    | 28 -> NONTERM_toplevellet 
    | 29 -> NONTERM_directive 
    | 30 -> NONTERM_directive 
    | 31 -> NONTERM_directive 
    | 32 -> NONTERM_main 
    | 33 -> NONTERM_main 
    | 34 -> NONTERM_main 
    | 35 -> NONTERM_main 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 32 
let _fsyacc_tagOfErrorTerminal = 30

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | EOT _ -> "EOT" 
  | HASHHELP _ -> "HASHHELP" 
  | HASHLOAD _ -> "HASHLOAD" 
  | HASHEXIT _ -> "HASHEXIT" 
  | LET _ -> "LET" 
  | REC _ -> "REC" 
  | IN _ -> "IN" 
  | EQUAL _ -> "EQUAL" 
  | LESSTHAN _ -> "LESSTHAN" 
  | GREATERTHAN _ -> "GREATERTHAN" 
  | LESSTHANEQ _ -> "LESSTHANEQ" 
  | GREATERTHANEQ _ -> "GREATERTHANEQ" 
  | ANDAND _ -> "ANDAND" 
  | PIPEPIPE _ -> "PIPEPIPE" 
  | PLUS _ -> "PLUS" 
  | MINUS _ -> "MINUS" 
  | STAR _ -> "STAR" 
  | SLASH _ -> "SLASH" 
  | INTEGER _ -> "INTEGER" 
  | IF _ -> "IF" 
  | THEN _ -> "THEN" 
  | ELSE _ -> "ELSE" 
  | TRUE _ -> "TRUE" 
  | FALSE _ -> "FALSE" 
  | LPAREN _ -> "LPAREN" 
  | RPAREN _ -> "RPAREN" 
  | FUN _ -> "FUN" 
  | RARROW _ -> "RARROW" 
  | VAR _ -> "VAR" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | EOT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | HASHHELP _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | HASHLOAD _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | HASHEXIT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LET _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | REC _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | IN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | EQUAL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LESSTHAN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | GREATERTHAN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LESSTHANEQ _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | GREATERTHANEQ _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ANDAND _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | PIPEPIPE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | PLUS _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | MINUS _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | STAR _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | SLASH _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INTEGER _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | IF _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | THEN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ELSE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | TRUE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | FALSE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LPAREN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RPAREN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | FUN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RARROW _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | VAR _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 32us; 65535us; 0us; 9us; 5us; 9us; 10us; 11us; 12us; 9us; 14us; 9us; 28us; 9us; 29us; 9us; 30us; 9us; 31us; 9us; 32us; 9us; 33us; 9us; 34us; 9us; 35us; 9us; 36us; 9us; 37us; 9us; 38us; 9us; 39us; 40us; 41us; 9us; 43us; 9us; 45us; 9us; 47us; 9us; 49us; 51us; 50us; 52us; 53us; 9us; 54us; 9us; 57us; 9us; 59us; 61us; 60us; 62us; 63us; 9us; 64us; 9us; 67us; 9us; 70us; 71us; 25us; 65535us; 0us; 10us; 5us; 10us; 12us; 10us; 14us; 10us; 28us; 10us; 29us; 10us; 30us; 10us; 31us; 10us; 32us; 10us; 33us; 10us; 34us; 10us; 35us; 10us; 36us; 10us; 37us; 10us; 38us; 10us; 41us; 10us; 43us; 10us; 45us; 10us; 47us; 10us; 53us; 10us; 54us; 10us; 57us; 10us; 63us; 10us; 64us; 10us; 67us; 10us; 25us; 65535us; 0us; 27us; 5us; 27us; 12us; 13us; 14us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 19us; 32us; 20us; 33us; 21us; 34us; 22us; 35us; 23us; 36us; 24us; 37us; 25us; 38us; 26us; 41us; 27us; 43us; 27us; 45us; 27us; 47us; 27us; 53us; 27us; 54us; 27us; 57us; 27us; 63us; 27us; 64us; 27us; 67us; 27us; 12us; 65535us; 0us; 73us; 5us; 6us; 41us; 42us; 43us; 44us; 45us; 46us; 47us; 48us; 53us; 55us; 54us; 56us; 57us; 58us; 63us; 65us; 64us; 66us; 67us; 68us; 1us; 65535us; 0us; 75us; 1us; 65535us; 0us; 77us; 1us; 65535us; 0us; 1us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 34us; 60us; 86us; 99us; 101us; 103us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 2us; 1us; 3us; 1us; 4us; 1us; 4us; 1us; 4us; 1us; 5us; 1us; 6us; 2us; 7us; 8us; 1us; 7us; 1us; 9us; 12us; 9us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 1us; 10us; 12us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 18us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 19us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 20us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 21us; 12us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 19us; 20us; 21us; 22us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 1us; 21us; 1us; 23us; 1us; 23us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 24us; 1us; 24us; 1us; 24us; 1us; 24us; 1us; 24us; 2us; 25us; 26us; 4us; 25us; 26us; 27us; 28us; 1us; 25us; 2us; 25us; 27us; 1us; 25us; 2us; 25us; 27us; 1us; 25us; 2us; 25us; 27us; 1us; 25us; 1us; 25us; 1us; 26us; 2us; 26us; 28us; 1us; 26us; 2us; 26us; 28us; 1us; 26us; 2us; 26us; 28us; 1us; 26us; 2us; 26us; 28us; 1us; 26us; 1us; 26us; 1us; 29us; 1us; 30us; 1us; 30us; 1us; 31us; 1us; 32us; 1us; 32us; 1us; 33us; 1us; 33us; 1us; 34us; 1us; 34us; 1us; 35us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 10us; 12us; 14us; 16us; 18us; 20us; 23us; 25us; 27us; 40us; 42us; 55us; 68us; 81us; 94us; 107us; 120us; 133us; 146us; 159us; 172us; 185us; 198us; 211us; 213us; 215us; 217us; 219us; 221us; 223us; 225us; 227us; 229us; 231us; 233us; 235us; 237us; 239us; 241us; 243us; 245us; 247us; 249us; 251us; 253us; 256us; 261us; 263us; 266us; 268us; 271us; 273us; 276us; 278us; 280us; 282us; 285us; 287us; 290us; 292us; 295us; 297us; 300us; 302us; 304us; 306us; 308us; 310us; 312us; 314us; 316us; 318us; 320us; 322us; 324us; |]
let _fsyacc_action_rows = 80
let _fsyacc_actionTableElements = [|14us; 32768us; 0us; 79us; 2us; 69us; 3us; 70us; 4us; 72us; 5us; 50us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 0us; 49152us; 0us; 16385us; 0us; 16386us; 0us; 16387us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 1us; 32768us; 26us; 7us; 0us; 16388us; 0us; 16389us; 0us; 16390us; 5us; 16392us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 0us; 16391us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 0us; 16393us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 0us; 16394us; 2us; 16395us; 17us; 30us; 18us; 31us; 2us; 16396us; 17us; 30us; 18us; 31us; 0us; 16397us; 0us; 16398us; 9us; 16399us; 8us; 34us; 9us; 35us; 10us; 36us; 11us; 37us; 12us; 38us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 9us; 16400us; 8us; 34us; 9us; 35us; 10us; 36us; 11us; 37us; 12us; 38us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 4us; 16401us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 4us; 16402us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 4us; 16403us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 4us; 16404us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 4us; 16405us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 11us; 16406us; 8us; 34us; 9us; 35us; 10us; 36us; 11us; 37us; 12us; 38us; 13us; 32us; 14us; 33us; 15us; 28us; 16us; 29us; 17us; 30us; 18us; 31us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 7us; 32768us; 15us; 12us; 16us; 14us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 5us; 32768us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 1us; 32768us; 28us; 41us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 0us; 16407us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 1us; 32768us; 21us; 45us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 1us; 32768us; 22us; 47us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 0us; 16408us; 6us; 32768us; 6us; 59us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 6us; 32768us; 6us; 60us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 1us; 32768us; 8us; 53us; 1us; 32768us; 8us; 54us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 1us; 32768us; 7us; 57us; 1us; 16411us; 7us; 57us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 0us; 16409us; 5us; 32768us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 5us; 32768us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 1us; 32768us; 8us; 63us; 1us; 32768us; 8us; 64us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 1us; 32768us; 7us; 67us; 1us; 16412us; 7us; 67us; 10us; 32768us; 5us; 49us; 15us; 12us; 16us; 14us; 19us; 4us; 20us; 43us; 23us; 2us; 24us; 3us; 25us; 5us; 27us; 39us; 29us; 8us; 0us; 16410us; 0us; 16413us; 5us; 32768us; 19us; 4us; 23us; 2us; 24us; 3us; 25us; 5us; 29us; 8us; 0us; 16414us; 0us; 16415us; 1us; 32768us; 1us; 74us; 0us; 16416us; 1us; 32768us; 1us; 76us; 0us; 16417us; 1us; 32768us; 1us; 78us; 0us; 16418us; 0us; 16419us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 15us; 16us; 17us; 18us; 19us; 30us; 32us; 33us; 34us; 35us; 41us; 42us; 50us; 51us; 59us; 60us; 63us; 66us; 67us; 68us; 78us; 88us; 93us; 98us; 103us; 108us; 113us; 125us; 133us; 141us; 149us; 157us; 165us; 173us; 181us; 189us; 197us; 205us; 213us; 219us; 221us; 232us; 233us; 244us; 246us; 257us; 259us; 270us; 271us; 278us; 285us; 287us; 289us; 300us; 311us; 313us; 315us; 326us; 327us; 333us; 339us; 341us; 343us; 354us; 365us; 367us; 369us; 380us; 381us; 382us; 388us; 389us; 390us; 392us; 393us; 395us; 396us; 398us; 399us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 1us; 1us; 3us; 1us; 1us; 2us; 1us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 4us; 6us; 6us; 7us; 4us; 5us; 1us; 2us; 1us; 2us; 2us; 2us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 1us; 1us; 1us; 1us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 4us; 4us; 4us; 5us; 5us; 6us; 6us; 6us; 7us; 7us; 7us; 7us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 16385us; 16386us; 16387us; 65535us; 65535us; 16388us; 16389us; 16390us; 65535us; 16391us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16407us; 65535us; 65535us; 65535us; 65535us; 65535us; 16408us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16409us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16410us; 16413us; 65535us; 16414us; 16415us; 65535us; 16416us; 65535us; 16417us; 65535us; 16418us; 16419us; |]
let _fsyacc_reductions ()  =    [| 
# 289 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.Toplevel in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startmain));
# 298 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "./Parser.fsy"
                                 Boolean true |> createTerm _1
                   )
# 36 "./Parser.fsy"
                 : 'gentype_atom));
# 309 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "./Parser.fsy"
                                  Boolean false |> createTerm _1
                   )
# 37 "./Parser.fsy"
                 : 'gentype_atom));
# 320 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "./Parser.fsy"
                                    
                             let i, pos = _1
                             Integer i |> createTerm pos
                         
                   )
# 38 "./Parser.fsy"
                 : 'gentype_atom));
# 334 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_term in
            let _3 = parseState.GetInput(3) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "./Parser.fsy"
                                               _2.TermTree |> createTerm _1
                   )
# 42 "./Parser.fsy"
                 : 'gentype_atom));
# 347 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string * Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "./Parser.fsy"
                                
                             let s, pos = _1
                             Var s |> createTerm pos
                         
                   )
# 43 "./Parser.fsy"
                 : 'gentype_atom));
# 361 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_atom in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "./Parser.fsy"
                                 _1
                   )
# 49 "./Parser.fsy"
                 : 'gentype_applist));
# 372 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_applist in
            let _2 = parseState.GetInput(2) :?> 'gentype_atom in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "./Parser.fsy"
                                         App (_1, _2) |> createTerm _1.TermInfo
                   )
# 50 "./Parser.fsy"
                 : 'gentype_applist));
# 384 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_applist in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "./Parser.fsy"
                                    _1
                   )
# 53 "./Parser.fsy"
                 : 'gentype_expr));
# 395 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "./Parser.fsy"
                                                  _2.TermTree |> createTerm _1
                   )
# 54 "./Parser.fsy"
                 : 'gentype_expr));
# 407 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "./Parser.fsy"
                                                    BinaryOp (Sub, {TermTree = Integer 0; TermInfo = _1}, _2) |> createTerm _1
                   )
# 55 "./Parser.fsy"
                 : 'gentype_expr));
# 419 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "./Parser.fsy"
                                           BinaryOp (Add, _1, _3) |> createTerm _1.TermInfo
                   )
# 56 "./Parser.fsy"
                 : 'gentype_expr));
# 432 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "./Parser.fsy"
                                            BinaryOp (Sub, _1, _3) |> createTerm _1.TermInfo
                   )
# 57 "./Parser.fsy"
                 : 'gentype_expr));
# 445 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "./Parser.fsy"
                                           BinaryOp (Mul, _1, _3) |> createTerm _1.TermInfo
                   )
# 58 "./Parser.fsy"
                 : 'gentype_expr));
# 458 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "./Parser.fsy"
                                            BinaryOp (Div, _1, _3) |> createTerm _1.TermInfo
                   )
# 59 "./Parser.fsy"
                 : 'gentype_expr));
# 471 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "./Parser.fsy"
                                             BinaryOp (And, _1, _3) |> createTerm _1.TermInfo
                   )
# 60 "./Parser.fsy"
                 : 'gentype_expr));
# 484 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "./Parser.fsy"
                                               BinaryOp (Or, _1, _3) |> createTerm _1.TermInfo
                   )
# 61 "./Parser.fsy"
                 : 'gentype_expr));
# 497 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "./Parser.fsy"
                                            BinaryOp (Equal, _1, _3) |> createTerm _1.TermInfo
                   )
# 62 "./Parser.fsy"
                 : 'gentype_expr));
# 510 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "./Parser.fsy"
                                               BinaryOp (Lt, _1, _3) |> createTerm _1.TermInfo
                   )
# 63 "./Parser.fsy"
                 : 'gentype_expr));
# 523 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "./Parser.fsy"
                                                  BinaryOp (Gt, _1, _3) |> createTerm _1.TermInfo
                   )
# 64 "./Parser.fsy"
                 : 'gentype_expr));
# 536 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "./Parser.fsy"
                                                 BinaryOp (Lte, _1, _3) |> createTerm _1.TermInfo
                   )
# 65 "./Parser.fsy"
                 : 'gentype_expr));
# 549 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "./Parser.fsy"
                                                    BinaryOp (Gte, _1, _3) |> createTerm _1.TermInfo
                   )
# 66 "./Parser.fsy"
                 : 'gentype_expr));
# 562 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "./Parser.fsy"
                                 _1
                   )
# 69 "./Parser.fsy"
                 : 'gentype_term));
# 573 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_atom in
            let _3 = parseState.GetInput(3) :?> Language.TermInfo in
            let _4 = parseState.GetInput(4) :?> 'gentype_term in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "./Parser.fsy"
                                                 
                             let arg = openVar _2
                             Abs (arg, _4) |> createTerm _1
                         
                   )
# 70 "./Parser.fsy"
                 : 'gentype_term));
# 590 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_term in
            let _3 = parseState.GetInput(3) :?> Language.TermInfo in
            let _4 = parseState.GetInput(4) :?> 'gentype_term in
            let _5 = parseState.GetInput(5) :?> Language.TermInfo in
            let _6 = parseState.GetInput(6) :?> 'gentype_term in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 74 "./Parser.fsy"
                                                        If (_2, _4, _6) |> createTerm _1
                   )
# 74 "./Parser.fsy"
                 : 'gentype_term));
# 606 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_atom in
            let _3 = parseState.GetInput(3) :?> Language.TermInfo in
            let _4 = parseState.GetInput(4) :?> 'gentype_term in
            let _5 = parseState.GetInput(5) :?> Language.TermInfo in
            let _6 = parseState.GetInput(6) :?> 'gentype_term in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "./Parser.fsy"
                                                        
                             let x = openVar _2
                             Let (x, _4, _6) |> createTerm _1
                         
                   )
# 75 "./Parser.fsy"
                 : 'gentype_term));
# 625 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_atom in
            let _4 = parseState.GetInput(4) :?> Language.TermInfo in
            let _5 = parseState.GetInput(5) :?> 'gentype_term in
            let _6 = parseState.GetInput(6) :?> Language.TermInfo in
            let _7 = parseState.GetInput(7) :?> 'gentype_term in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 79 "./Parser.fsy"
                                                            
                             let x = openVar _3
                             LetRec (x, _5, _7) |> createTerm _1
                         
                   )
# 79 "./Parser.fsy"
                 : 'gentype_term));
# 645 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_atom in
            let _3 = parseState.GetInput(3) :?> Language.TermInfo in
            let _4 = parseState.GetInput(4) :?> 'gentype_term in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 85 "./Parser.fsy"
                                                
                             let x = openVar _2
                             x, _4.TermTree |> createTerm _1
                         
                   )
# 85 "./Parser.fsy"
                 : 'gentype_toplevellet));
# 662 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            let _3 = parseState.GetInput(3) :?> 'gentype_atom in
            let _4 = parseState.GetInput(4) :?> Language.TermInfo in
            let _5 = parseState.GetInput(5) :?> 'gentype_term in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 89 "./Parser.fsy"
                                                    
                             let x = openVar _3
                             x, LetRec (x, _5, _3) |> createTerm _1
                         
                   )
# 89 "./Parser.fsy"
                 : 'gentype_toplevellet));
# 680 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 95 "./Parser.fsy"
                                     Help
                   )
# 95 "./Parser.fsy"
                 : 'gentype_directive));
# 691 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            let _2 = parseState.GetInput(2) :?> 'gentype_atom in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "./Parser.fsy"
                                          
                             let file = openVar _2
                             Load file
                         
                   )
# 96 "./Parser.fsy"
                 : 'gentype_directive));
# 706 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 100 "./Parser.fsy"
                                     Exit
                   )
# 100 "./Parser.fsy"
                 : 'gentype_directive));
# 717 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_term in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 103 "./Parser.fsy"
                                     Term _1
                   )
# 103 "./Parser.fsy"
                 : Language.Toplevel));
# 729 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_toplevellet in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 104 "./Parser.fsy"
                                            ToplevelLet _1
                   )
# 104 "./Parser.fsy"
                 : Language.Toplevel));
# 741 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_directive in
            let _2 = parseState.GetInput(2) :?> Language.TermInfo in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 105 "./Parser.fsy"
                                          Directive _1
                   )
# 105 "./Parser.fsy"
                 : Language.Toplevel));
# 753 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 106 "./Parser.fsy"
                                Eof
                   )
# 106 "./Parser.fsy"
                 : Language.Toplevel));
|]
# 764 "Parser.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 33;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let main lexer lexbuf : Language.Toplevel =
    engine lexer lexbuf 0 :?> _
