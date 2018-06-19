# 坦克的AI设计
--------------
## 游戏
这次我制作了一个简单的坦克AI，玩家通过WASD控制坦克移动，空格进行射击。地图中有5架敌军坦克，会自动追踪玩家，当玩家进入射程时对玩家射击。玩家被击毁时游戏失败，击毁5架敌军坦克则获胜（忘记做获胜和失败提示）。

## 演示
+ 场景
![plane](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Plane.png)
+ [演示视频](https://pan.baidu.com/s/1UCd-Qk4OLCmzgr4dTmVoyw)

## 介绍
+ 在游戏商店下载Tank！Tutorial游戏项目，但只会用到里面的一些模型，游戏的运行全部由代码控制。完整的代码可以在Scripts文件夹里找到，这里说一下如果想成功完成游戏，需要哪些代码以外的操作。
![Tanks](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Tanks.jpg)

+ 在项目的Models文件夹里找到Tank和Shell的模型，制作成Player、Enemy和Bullet预制。
![prefabs](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Prefabs.png)

+ 把Prefabs文件里的LevelArt预制拖到场景中，由于我写代码时忘记添加Player，所以后来运行时我直接拖了一个Player进场景中，这样我们就得到了一张地图。接着通过Navigation窗口改变地图中各构成的Navigation属性，分成可以行走的Ground、Dune，以及不可以行走的其他元素。这个步骤只能一个一个地改，比较繁琐。Navigation属性如下图所示：
![walkable](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/walkable.png)
![unwalkable](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/unwalkable.png)

+ 在Player的预制中添加Player标签（很重要）、刚体、碰撞框、NavMeshAgent、IUserGUI脚本和Player脚本。
![Player](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Player.jpg)

+ 在Tank的预制中添加Enemy标签（很重要）、刚体、碰撞框、NavMeshAgent和Enemy脚本。
![Tank](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Tank.jpg)

+ 最后就是把SceneControler脚本和Factory脚本添加到主摄像机中，再给Player、Tank和Bullet拖到相应GameObject变量框中。如下图所示：
![SceneControler](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Scene%20Controller.png)
![Factory](https://raw.githubusercontent.com/MapleLai/Homework9/master/Screenshot/Factory.png)
