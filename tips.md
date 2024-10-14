## OnValueChanged
同期変数が更新されたときに実行されるやつ  
OnValueChangedは普通に`SendCustomNetworkEvent`を使うより高速らしく、ほとんど誤差がないくらいみたいで  
書き方が独特なのでメモ  
C#のプロパティの書き方に似ているそうだけど、使ったことないし......
```
[UdonSynced, FieldChangeCallback(nameof(SyncedVariable))] private int _syncedVariable;

public int SyncedVariable
{
    get => _syncedVariable;
    set
    {
        _syncedVariable = value;
        // 以下、任意の処理
    }
}

void Start(){
    // 代入
    SyncedVariable = 10;
    // 取り出し
    int hoge = SyncedVariable;
}
```
一行ずつ解説  
`[UdonSynced, FieldChangeCallback(nameof(SyncedVariable))] private int _syncedVariable;`
Udonsyncedは言わずもがな、同期変数として宣言するやつ。必要  
`FieldChangeCallback(nameof(SyncedVariable))`はコールバック関数で、動きの部分の本体  
`private int _syncedVariable;` 通常通りの変数宣言。値が入る部分の本体だけど、これに対して直接値を入れるようには使わず、コールバック関数を介して代入する感じ  

`public int SyncedVariable` コールバック関数
`get => _syncedVariable;` 値を取り出すときに実行される部分。`int hoge = SyncedVariable;`の時にここが実行され、`_syncedVariable`の中身が渡される

```
set
{
    _syncedVariable = value;
    // 以下、任意の処理
}
```
ここはひとまとめに解説  
`SyncedVariable = 10;`が実行された時に、setブロック内のコードが実行される  
`_syncedVariable = value;` これが値を代入しているところ。上記ではvalueに10が入っており、それを本体の`_syncedVariable`に入れるイメージ
`// 以下、任意の処理` 値が入った後に個々の処理が実行される。これが`SendCustomNetworkEvent`よりも早いそうで。　　
[SimpleNetwork](https://github.com/tutinoco/SimpleNetwork)はこれを用いて低遅延のを実現しているらしい。  
使ってみたいけどあんまりライセンスとかわからない......
