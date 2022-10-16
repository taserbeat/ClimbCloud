# Unity と VSCode の設定を確認するプロジェクト

これは Unity と VSCode の環境構築、および設定を動作確認するためのプロジェクトである。  
目的とする動作確認の内容は以下の通りとなる。

- Unity から`Open C# Project`で VSCode が起動する (Unity + VSCode の連携)

- VSCode で C#ソースファイルのインテリセンスが有効になる

# 動作環境

| 名称     | バージョン                     | 備考                                   |
| -------- | ------------------------------ | -------------------------------------- |
| MacOS    | 12.6 (Monterey)                | Intel CPU                              |
| Unity    | 2021.3.11f1 Personal           | 2022 年 10 月 16 日時点で最新の LTS 版 |
| VSCode   | バージョン: 1.72.2 (Universal) |                                        |
| .NET SDK | 6.0.200                        |                                        |

# 設定方法

目的の動作を再現するために必要な設定については以下の通りとなる。

## Unity から VSCode を起動する

メニューから【Unity】 -> 【Preferences】 -> 【External Script Editor】を`Visual Studio Code`に設定する。

Unity のプロジェクトビューを右クリックし、`Open C# Project`をクリックして VSCode が起動すれば動作確認が可能。

## VSCode で C#スクリプトのインテリセンスを有効にする

HomeBrew から`mono`をインストールする。

```bash
brew update && brew install mono
```

VSCode を再起動(必ず終了する)し、Unity のプロジェクトを開く。

VSCode の設定ファイルである`settings.json`を作成し、以下の項目を追加する。

```json
{
  "omnisharp.useModernNet": false
}
```

追加後、OmniSharp が再起動されたら C#ソースファイルを適当に触ってインテリセンスが有効になっていることを確認する。
