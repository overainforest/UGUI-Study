# 一级标题
- 点
- 点
- 点
## 二级标题
将unity项目导入github学习[链接1]

将unity项目导入github学习[链接2]

[链接1]:https://www.bilibili.com/video/BV1DG4y1n7md?spm_id_from=333.788.videopod.sections&vd_source=e63dfb917f28c876d5f81989de3455d8
[链接2]:https://www.bilibili.com/video/BV1id4y1c7AZ?spm_id_from=333.788.videopod.sections&vd_source=e63dfb917f28c876d5f81989de3455d8

## 代码块格式
```gitignore
开始：```gitignore
内容：你需要撰写的内容
结尾：```
```
## 解决本地冲突

情景：在GitHub上添加了某个文件，如：README.md，又在本地修改了其他代码，发现使用git push失败。

- 将本地状态调整至上次提交的状态，保留本地修改

```gitignore
git stash
```

- 拉取github内容至本地

```gitignore
git pull
```

出现新的编辑器界面-无法编辑

1.按下i进入编辑模式

2.更改黄色字体内容（可输入任意内容或不更改，目的是写明原因）

3.按下ECS进入命令模式（输入的内容在命令行窗口最下方显示）

4.输入如下内容
```gitignore
:wq
```
:w——表示 ​​write（写入/保存）

:q—— 表示 ​​quit（退出）​​ Vim 编辑器。

:wq即保存并退出编辑界面

输入后会回到命令行

- 重新执行本地修改

```gitignore
git stash pop
```

- 将本地修改提交（假设你当前在分支 `main`上）

```gitignore
git push origin main
```