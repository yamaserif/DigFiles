[説明書(日本語)](https://github.com/yamaserif/digFiles/blob/main/README_jp.md) | [readme(English)](https://github.com/yamaserif/digFiles/blob/main/README.md)

# digFiles
In programming, it is often recommended to divide processes into functions or files for reuse in terms of readability and maintainability of source code. 

"digFiles" enforces the division of processes by setting a limit on the number of files and the way they are described using a folder/file structure.

## specification
- The folder will contain "0 or more folders" OR "0 to 1 file". 
- The extension does not affect the processing. 
- The ActionId is the order of execution in "ascending order in case of case-insensitive string comparison of ordinal numbers". (Corresponds to "StringComparer.OrdinalIgnoreCase" in C#.)   

（Note that '《' and '》' should not be written when actually filling in the form. ）  
（The "_《arbitrary character》" can be omitted.） 
 
### folder name 
|  notation                            |  meaning                                                                                                              |
| ------------------------------------ | --------------------------------------------------------------------------------------------------------------------- |
| 《ActionId》_《arbitrary character》  | [Action block (definition)]A block of actions (executed in the same hierarchy in the order of the youngest action id) |
| 《#ActionId》_《arbitrary character》 | [Action block (definition)]A block of actions (only executed in [Action block (call)]                                 |
 
### file name 
|  notation                            |  meaning                            |
| ------------------------------------ | ----------------------------------- |
| 《Command》_《arbitrary character》   | [Action piece]Action                |
| 《*ActionId》_《arbitrary character》 | [Action block (call)]Calling action |

### File Contents 
Multiple arguments separated by spaces (see "Command" for details)  
When "《VariableId》" is an argument, the value set in the variable can be interpreted as "VariableId" by writing "《*VariableId》".
 
### Command         
|  Command |  Variable                                |  Action                                                                       |
| -------- | ---------------------------------------- | ----------------------------------------------------------------------------- |
| set      | 《VariableId》 《value》                  | assignment                                                                    |
| copy     | 《VariableId》 《VariableId》             | Copying Variables                                                             |
| in       | 《VariableId》                            | 1 character input (utf-8)                                                     |
| out      | 《VariableId》                            | 1 character output (utf-8)                                                    |
| loop     | 《VariableId》 《VariableId》 《ActionId》 | Performs the specified action as long as the two variables are of equal value |
| add      | 《VariableId》 《VariableId》              | Add the second variable to the first variable                                 |
