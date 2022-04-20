[説明書(日本語)](https://github.com/yamaserif/DigFiles/blob/main/interpreter/README_jp.md) | [readme(English)](https://github.com/yamaserif/DigFiles/blob/main/interpreter/README.md)

# DigFilesインタプリタ
このプロジェクトはC#製のDigFilesインタプリタになります。

## インタプリタの制限
変数id: -2,147,483,648 ～ 2,147,483,647
値: -2,147,483,648 ～ 2,147,483,647

## 使い方
各自「DigFiles_interpreter」プロジェクトをビルドして実行してください。
このときDEBUGビルド時は内部の変数テーブル等が確認できるようになっています。

また、パスや入力値はコマンドライン引数によって与えられます。
|  引数       |  内容                                                                        |
| ----------- | ---------------------------------------------------------------------------- |
| args[0]     | DigFilesプログラムのパス                                                     |
| args[1]以降 | DigFilesプログラムに与える入力（スペースはインタプリタ内で自動補完されます） |

「DigFiles_Test」はNUnitにて書かれたテスト用のプロジェクトですので、ご注意ください。
