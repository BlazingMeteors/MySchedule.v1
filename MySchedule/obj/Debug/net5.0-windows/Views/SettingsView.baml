   M S B A M L   `   `   `  ����E  AMySchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MySchedule.ViewsMySchedule.Views  5      =#clr-namespace:MySchedule.ExtensionsMySchedule.Extensions  5
      #    MySchedule.Views.SettingsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MySchedule.Views     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5	      6
extensions#clr-namespace:MySchedule.Extensions  	 5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��20,10q�6   $��26(�5      $
��Bold"�5      $��设置��5      �� 5   
   ���#DDDDDD$��	0,0,0,0.3q�5      � 5   
   $��1��6   $��50q�6    � ColumnDefinitions 5      �� 5      $	��220 �6#   �� 5      .+�5      �� -   5         ��Name$ listBox1��5          ListBoxItemStyle#��[  5      ��5!      �� *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5"      +  %Microsoft.Xaml.Behaviors.EventTrigger  5#         	EventName$ SelectionChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5$      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *NavigateCommand+   CommandParameter 5%   0   ��  �� ElementName$ listBox1��	 �� Path$	 SelectedItem�5&      ��5(      �� 5)      .R�5*      �� 
 �� Orientation$
 
Horizontal=�6%   
������ .+�5,      '  !MaterialDesignThemes.Wpf.PackIcon  $
��15,0q�66   $��25��5.   6   $��25��5/   6      Kind 5-   6   �� *Icon+5/   6   �� 50      $
��10,0q�6(   $��20(�52   (   $
��Bold"�53   (   ��51   (   �� *Title+53   (   �� 54      ���#DDDDDD$��1q�55   %   56      58      5:      �� 5;      $��1��6   $
��10,0q�5<      (  "MySchedule.Extensions.PrismManager   SettingsViewRegionName! 	 Prism.Regions.RegionManager   
RegionName# Z 5=      5>      5?      5@      