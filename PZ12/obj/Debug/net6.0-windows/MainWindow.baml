   M S B A M L   `   `   `  ?????  ;PZ12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PZ12PZ12  5   	       PZ12.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:PZ12     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ]? $
??True??6   .+?5
   
   ?? 
???????$??Bottom=?6*   $??20??6B   .@?5      ?? .??5      ?? -   5        $??CursorPosition??5      5      ?? 5      .??5      ?? -   5        $??ChangedText??5      5      5      ?? 5   
   $	??Top=?6   $??42??6*   .+?5      o? .@?5      m? $
??File??6   .@?5      m? -   5         m?Name$
 Open??5      $
??Open??6-   6;   m? 5      -   5        $	 New??5      $	??New??6,   69   m? 5      -   5        $
 Save??5      $
??Save??6-   6;   m? 5      -   5        $ Delete??5      $??Delete??6/   6?   5      m? 5      -   5        $ Sample??5      $??Sample??6+   .@?5      m? -   5        $ Create??5      $??Create??6/   m? 5      -	   5        $
 Load??5      $
??Load??6-   m? 5      -
   5        $ Load1??5      $??Load1??6.   5!      m? 5$      -   5        $ About??5$      $??About??6*   .@?5%      m? -   5        $ AboutP??5%      $??About program??6/   m? 5&      -   5        $ AboutA??5&      $??About authors??6/   5'      5(      ? 5)      $??24??6   .+?5*      d? -   5        $
??btnB??5*   D   $ ??EditingCommands.ToggleBold??6   $??20??6P   $??23??6[   .??5+      ?? $??	Res/b.png??6   5,      d? 5-      -   5        $
??btnI??5-   F   $"??EditingCommands.ToggleItalic??6   $??20??6R   $??23??6]   .??5.      ?? $??	Res/i.png??6   5/      d? 50      -   5        $
??btnU??50   I   $%??EditingCommands.ToggleUnderline??6   $??20??6U   $??23??6`   .??51      ?? $??	Res/u.png??6   52      53      54      ? 55   
    ? ColumnDefinitions 56      ?? 57      $??* ?6#   ?? 58      $??3* ?6#   .+?5;      ?? -   5         ??Name$ 
TextEditor??5;      
???????$??1??6A    ?? 	IsEnabled$
 True??5<       ?? 
AcceptsTab$
 True??62    ?? AcceptsReturn$
 True??5=      5>      ?? 5@      -   5        $??Files??5@   R    ?? SelectionMode$ Multiple=?6   
???????$??0??6B   5B      5D      5H      5I      