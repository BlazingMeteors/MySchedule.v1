   M S B A M L   `   `   `  ����E  AMySchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MySchedule.ViewsMySchedule.Views  5      K*clr-namespace:MySchedule.Common.ConvertersMySchedule.Common.Converters  5
           MySchedule.Views.IndexView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MySchedule.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5	      3cv*clr-namespace:MySchedule.Common.Converters 	 5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � 	Resources 5      5   /MySchedule.Common.Converters.IntToBoolConverter   	intToBool��%   &	          5   
   6    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $
��15,8q�5      $��20(�5      ��5      �� *Title+5      �� 5   
   $��1��6   ��5      �� *
TaskBars+��5      �� 5      .R�5       A�  A� Columns$ 4��6"   5!      ��5#      �� 5$      .R�5%      �� $��10q�5&       �� CornerRadius$ 5��5'      ��5%      �� *Color+ J� InputBindings 5(      d� 5)       d� MouseAction$ 	LeftClicke�6+    �� Command 5*   +   �� *DataContext.NavigateCommand+ �� RelativeSource �� 	 �� Mode$	 FindAncestor=�
 �� AncestorType
 ItemsControl �� CommandParameter 5+   +   �� ��5-      �� 5.       �� 
TargetType" ��6$    �� Triggers 5/   "   P� 50   &    P� Property �@J�IsMouseOver P� Value$
 True��51   .   . �52   *   ��  �� Property �@J�Effect �� Value 53   .   3  -System.Windows.Media.Effects.DropShadowEffect  54   2      Color$ #DDDDDD��6C      ShadowDepth$ 2Q�55   C      
BlurRadius$ 10Q�56   C   58   +   59   '   5;      ._�5=      � .+�5>      �� $��15,10q�6)   .+�5?   "   '  !MaterialDesignThemes.Wpf.PackIcon  $
��0,10q�6:   $��30��5A   :   $��30��5B   :      Kind 5@   :   �� *Icon+5B   :   �� 5C   "   $	��0,6q�5D   ,   $��15(�5E   ,   $
��Bold"�5F   ,   ��5C   ,   �� *Title+5F   ,   �� 5G   "   $
��Bold"�6,   $��40(�5I   ,   $	��0,8q�5J   ,   ��5H   ,   �� *	Content+5J   ,   5K      �� 5L      $
}�True��6%   .+�5M   "   �� 
 �� Top$ 10��6)    �� Right$	 -50��5N   )   $	��120��5O   )   $	��120��5P   )   ���#FFFFFF$	 100��5R   )    J� Opacity$	 0.1Q�5S   )   �� 5T   "   $ 80��6)   $	 -30��5U   )   $	��120��5V   )   $	��120��5W   )   ���#FFFFFF$	 100��5Y   )   $	 0.1Q�5Z   )   5[      5\      5]      5^      5`      � 5a   
   $��2��6   $	��0,6q�6    � ColumnDefinitions 5b      �� 5c      �� 5d      .+�5f      �� $
��10,4q�6   ���#BEBEBE$ 5��5h      $	 0.1Q�5i      ]� 5j      $
��10,0q�6   .+�5k      ]� $
��10,0q�6   $��False��5l      $	��Top=�5m      .+�5n      �� $��待办事项��6    $��20(�5o       $
��Bold"�5p       $
��5,15q�62   �� 5q      $
��5,13q�6   $��30��5r      $��30��5s      $	��Top=�5t      $��Right=�5u       , (MaterialDesignFloatingActionAccentButton#��[ 5v      $��新增待办��5x      ��5w      �� *ExecuteCommand+.��5y        $	 Add=�62   5z      5{      �� 5|      $��Hidden=�5}      $��Stretch=�5~      ��5|      �� *Summary.ToDoList+* 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$ MouseDoubleClick��6)   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�      2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *EditToDoCommand+   CommandParameter 5�   4   ��  �� ElementName$ todoList��  �� Path$  SelectedItem�5�      ��5�      �� 5�      .R�5�      ]� $��80��6(   $��False��5�   (   .+�5�   "   d� $��Right=�6/   ! d� 	IsChecked! 5�   /   �� *Status+" �� 	Converter#" [  ��5�   /   �� *!DataContext.ToDoCompltedCommand+ �� $	 FindAncestor=�
 ItemsControl��5�   /   �� �� 5�   "   .+�5�   &   �� $��16(�5�   0   $
��Bold"�5�   0   ��5�   0   �� *Title+5�   0   �� 5�   &   $	 0.5Q�5�   0   $	��0,5q�5�   0   ��5�   0   �� *	Content+5�   0   5�   #   5�      5�      5�      5�      �� 5�      $
��10,4q�6   $��1��6#   ���#BEBEBE$ 5��5�      $	 0.1Q�5�      ]� 5�      $
��10,0q�6   $��1��6&   .+�5�      ]� $
��10,0q�6   $��False��5�      $	��Top=�5�      .+�5�      �� $��	备忘录��6    $��20(�5�       $
��Bold"�5�       $
��5,15q�5�       �� 5�      $
��5,13q�6   $��30��5�      $��30��5�      $	��Top=�5�      $��Right=�5�      #��[ 5�      # � Cursor$
# Hand��5�      $��新增备忘录��5�      ��5�      �� *ExecuteCommand+.��5�        $	 Add=�62   5�      5�      �� 5�      $��Hidden=�5�      $��Stretch=�5�      ��5�      �� *Summary.MemoList+ 5�        5�      $ MouseDoubleClick��6)   . 5�         64   �� *EditMemoCommand+ 5�   4   �� $ memoList��$  SelectedItem�5�      ��5�      �� 5�      .R�5�      ]� $��80��6(   $��False��67   .+�5�   "   d� $��Right=�6/   �� 5�   "   .+�5�   &   �� $��16(�5�   0   $
��Bold"�5�   0   ��5�   0   �� *Title+5�   0   �� 5�   &   $	 0.5Q�5�   0   $	��0,5q�5�   0   ��5�   0   �� *	Content+5�   0   5�   #   5�      5�      5�      5�      5�      5�      5�      