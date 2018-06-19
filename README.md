# 坦克的AI设计
--------------
## 介绍


## 演示
+ 场景
![plane](https://raw.githubusercontent.com/MapleLai/Homework7/master/Screenshot/%E5%9C%BA%E6%99%AF.png)
+ [演示视频](https://pan.baidu.com/s/1UCd-Qk4OLCmzgr4dTmVoyw)

## 简答介绍
+ 在游戏商店下载Tank！Tutorial游戏项目，但只会用到里面的一些模型，游戏的运行全部由代码控制。完整的代码可以在Scripts文件夹里找到，这里说一下如果想成功完成游戏，需要哪些代码以外的操作。
![Tanks](https://raw.githubusercontent.com/MapleLai/Homework7/master/Screenshot/%E5%9C%BA%E6%99%AF.png)

+ 在项目的Models文件夹里找到Tank和Shell的模型，制作成Player、Enemy和Bullet预制。
![prefabs](https://raw.githubusercontent.com/MapleLai/Homework7/master/Screenshot/%E5%9C%BA%E6%99%AF.png)

+ 把Prefabs文件里的把LevelArt预制拖到场景中，这样我们就得到了一张地图。接着通过Navigation窗口改变地图中各构成的Navigation属性，分成可以行走的Ground、Dune，以及不可以行走的其他元素。这个步骤只能一个一个地改，比较繁琐。Navigation属性如下图所示：
![walkable](https://raw.githubusercontent.com/MapleLai/Homework7/master/Screenshot/%E5%9C%BA%E6%99%AF.png)
![unwalkable](https://raw.githubusercontent.com/MapleLai/Homework7/master/Screenshot/%E5%9C%BA%E6%99%AF.png)

+ 
