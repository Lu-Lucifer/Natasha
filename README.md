# Natasha
去除IL操作，像正常人一样创造你的动态代码。

重启项目，使用roslyn方案。

欢迎参与讨论：[点击加入Gitter讨论组](https://gitter.im/dotnetcore/Natasha)

- ### 项目计划

- **2019/05中 功能计划**：  

   -------
   - [x]  **脚本引擎&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]**

     - [x]  动态编译&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
     - [x]  动态构造&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
          - [x] 扩展模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] Method模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;[##########][100%]  
          - [x] 反解器&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 类型反解&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 参数反解&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 字段反解&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
          - [x] 构造器&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
   -------
   - [x]  **动态调用&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]**  
   
      - [x] 本地调用(字段+属性)&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;&ensp;&nbsp;&nbsp;&nbsp;[##########][100%]
      - [x] 远程调用(Json序列化)&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;[##########][100%]
    -------
    - [x]  **动态实现&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]**  
    
      - [x] 接口动态实现&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;&ensp;[##########][100%]
      - [x] 方法动态实现&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;&ensp;[##########][100%]
      - [x] 类型动态实现&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;&ensp;[##########][100%]
      - [x] 动态初始化实现&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&ensp;&ensp;[##########][100%]
      - [x] 动态深度克隆实现(迭代接口排除)&emsp;&ensp;[##########][100%]
   -------
   
 
- **2019/05末 功能计划**：  

   -------
   - [x]  **脚本引擎&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]**  
   
      - [x]  动态构造&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
          - [x] 扩展模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 类模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]  
            - [x] 方法模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]  
            - [x] 参数模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]  
            - [x] 初始化模板&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]  
          - [x] 反解器&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 命名反解&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 声明反解&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 访问级别反解&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
            - [x] 修饰符级别反解&emsp;&emsp;&emsp;&emsp;&emsp;[##########][100%]
   -------
<br/>
<br/>  

- **测试计划（等待下一版本bechmark）**：
      
     - [ ]  **动态函数性能测试（对照组： emit, origin）**  
     - [ ]  **动态调用性能测试（对照组： 动态直接调用，动态代理调用，emit, origin）**  
     - [ ]  **动态克隆性能测试（对照组： origin）**
     - [ ]  **远程动态封装函数性能测试（对照组： 动态函数，emit, origin）**

- **优化计划**：

     - [x]  **动态编译模块**  
        - [x]  评估“流加载模式”以及“文件加载”模式的资源占用情况  
        
            内存流： <img src="https://github.com/dotnetcore/Natasha/blob/master/Image/memory.png" height="300" width="250" alt="程序集内存流编译"/>
            文件流： <img src="https://github.com/dotnetcore/Natasha/blob/master/Image/file.png" height="300" width="250" alt="程序集文件编译"/>
        - [x]  优化引擎，区分编译方式，增加内存流编译加载。
     - [x]  **动态构造模块**  
        - [x]  抽象出最基方法
        - [x]  采用部分类规整目录结构
     - [x]  **分离类库**  
     - [x]  **分层动态实现**
        - [x]  优化脚本构造模板
        - [x]  在模板上打造Builder
        - [x]  根据Builder定制操作类
        
            
      
     
