   M S B A M L   `   `   `  ����E  AMySchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MySchedule
MySchedule  5      =#clr-namespace:MySchedule.ExtensionsMySchedule.Extensions  5          MySchedule.Views.MainView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      *localclr-namespace:MySchedule     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      6
extensions#clr-namespace:MySchedule.Extensions   5      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5      $��微软雅黑)�5       � Title$ 
MainWindow��5      $	��768��5      $
��1280��5       � WindowStyle$
 None=�5       � WindowStartupLocation$ CenterScreen=�5       � AllowsTransparency$
 True��5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 
DialogHost��5   	      
Identifier$
 Root��5   	   	   DialogTheme$	 Inherit=�5   	   .��5    
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5        
  Name$
 
DrawerHost��5!         IsLeftDrawerOpen 5"      ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked�   LeftDrawerContent 5#      ]� 5$      $	��220��5%      .+�5&      �� $
��0,20q�6!   $	��Top=�6/   .+�5'      �� $��5q�5(      $��50��5)      $��50��5*      $��/Images/User2.jpg��5+       J� Clip 5,      @� 5-   "    @� RadiusX$ 25Q�5.   %    @� RadiusY$ 25Q�5/   %    @� Center$ 25,25&�50   %   52      �� 53      $	��0,8q�54      $��Center=�55      $��ZY��56      57      �� 59      -   5         ��Name$ listBox1��59   U     ListBoxItemStyle#��[ 6   ��6g   �� *
MenuBars+* 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5:      + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5;         	EventName$ SelectionChanged��6-   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5<   "   2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *NavigateCommand+   CommandParameter 5=   8   �� $ listBox1��$ SelectedItem�5>      ��5A      �� 5B      .R�5C   "   ��  �� Orientation$ 
Horizontal=�5D   %   
������ .+�5F   &   '	  !MaterialDesignThemes.Wpf.PackIcon	  $
��15,0q�5G   )    	  Kind 5H   )   �� *Icon+�� 5I   &   $
��10,0q�5J   )   ��5K   )   �� *Title+5L   #   5M      5O      5P      .��5S      ]� .+�5V      (
  "MaterialDesignThemes.Wpf.ColorZone
  -   5         
 Name$ TopZone��5X      $��16q�5W      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5Y       
  Mode$ 
PrimaryMid=�5Z      $	��Top=�5[      .��5\      ]� $
��True��5]      .+�5^      �� $��Right=�5_      $ 
Horizontal=�5`      .+�5a      �� $��25��5b   !   $��25��5c   !   $��/Images/User2.jpg��5d   !    5e   "   @� 5f   &   $
 12.5Q�5g   )   $
 12.5Q�5h   )   $ 	12.5,12.5&�5i   )   5k      �� 5l      -   5         ��Name$ btnMin��5m   !   $	��—��5n   !    ! MaterialDesignFlatMidBgButton#��[ 5o   !    � Cursor$
 Hand��5p   !   �� 5q      -   5        $ btnMax��5r   !   $	��☐��5s   !   #��[ 5t   !   �� 5u      -   5        $ btnClose��5v   !   $	��✕��5w   !   #��[ 5x   !   5y      �� 5z      $ 
Horizontal=�5{      .+�5|      d� -   5          d�Name$  MenuToggleButton��5}   !    ' #MaterialDesignHamburgerToggleButton#��[ 5~   !   ! d� 	IsChecked$! FalseY�5   !   4  .System.Windows.Automation.AutomationProperties"   Name$" HamburgerToggleButton��5�   !   �� 5�      $��24,0,0,0q�5�   !   # � ToolTip$# Previous Item��5�   !     MaterialDesignToolButton#��[ 5�   !   ��5�   !   �� *GoBackCommand+��5�   !   0  *MaterialDesignThemes.Wpf.PackIconExtension  $   Kind$$ 	ArrowLeft=�%   Size% 24��5�   !   �� & �� RelativeSource& �� ' �� AncestorType"' �$ (TextElement.Foreground)�+  %MaterialDesignThemes.Wpf.RippleAssist(   Feedback( 5�   !   �� & �� *Self+$ 
Foreground�  BrushRoundConverter) �� 	Converter#) [ �� 5�      $��16,0,0,0q�5�   !   $# 	Next Item��5�   !   #��[ 5�   !   ��5�   !   �� *GoForwardCommand+��5�   !     $$ 
ArrowRight=�% 24��5�   !   �� & �� "' �$ (TextElement.Foreground)�( 5�   !   �� & �� *Self+$ 
Foreground�#) [ �� 5�      $
��16,0q�5�   !   $��Center=�5�   !   $��Center=�5�   !   $��22(�5�   !   $%" Material Design In XAML Toolkit��5�   !   $��日程安排��5�   !   5�      5�      5�      �� 5�      (  "MySchedule.Extensions.PrismManager*   MainViewRegionName!  Prism.Regions.RegionManager+   
RegionName#+ Z* 6!   5�      5�      5�      5�      