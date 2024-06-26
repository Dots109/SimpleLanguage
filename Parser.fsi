// Signature file for parser generated by fsyacc
module Parser
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
type nonTerminalId = 
    | NONTERM__startmain
    | NONTERM_atom
    | NONTERM_applist
    | NONTERM_expr
    | NONTERM_term
    | NONTERM_toplevellet
    | NONTERM_directive
    | NONTERM_main
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val main : (FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> FSharp.Text.Lexing.LexBuffer<'cty> -> (Language.Toplevel) 
