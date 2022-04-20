[説明書(日本語)](https://github.com/yamaserif/DigFiles/blob/main/interpreter/README_jp.md) | [readme(English)](https://github.com/yamaserif/DigFiles/blob/main/interpreter/README.md)

# DigFiles Interpreter
This project is a DigFiles interpreter made in C#.

## Interpreter Limits
VariableId: -2,147,483,648 ～ 2,147,483,647
value: -2,147,483,648 ～ 2,147,483,647

## How to use
Build and run the "DigFiles_interpreter" project on your own.
At this time, the internal variable tables, etc. can be checked when DEBUG is built.

Paths and input values are also given by command line arguments.
|  arguments           |  Contents                                                                                |
| -------------------- | ---------------------------------------------------------------------------------------- |
| args[0]              | DigFiles program path                                                                    |
| on and after args[1] | Input to be given to the DigFiles program (spaces are auto-completed in the interpreter) |

Please note that "DigFiles_Test" is a test project written in NUnit.
