   M S B A M L   `   `   `  ����O  KTaskManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TaskManagementSystem.ViewsTaskManagementSystem.Views  5   	   Q-clr-namespace:TaskManagementSystem.ViewModelsTaskManagementSystem.ViewModels  5   	   +    %TaskManagementSystem.Views.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:TaskManagementSystem.Views     5   	   D
viewModels-clr-namespace:TaskManagementSystem.ViewModels     5   	     � Title$  Task Management System��5	   	   $	��600��6(   $	��800��65    � DataContext 5      3   -TaskManagementSystem.ViewModels.MainViewModel  5   
   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Task Details��6    $��0,0,0,10q�66   .��5      � $��5q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $��* �6'    5      �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   .+�5$      �� $��0��6   $��0��6%   $��
Task Name:��65   �� 5%      $��0��6   $��1��6'   $��3��67   $��5q�5&   Y   ��6   �� *
TaskName+ �� UpdateSourceTrigger$ PropertyChanged=�6Y   �� 5(      $��1��6   $��0��6%   $��Date:��65   (  "System.Windows.Controls.DatePicker  5)      $��1��6   $��1��6*   $��5q�5*   ?      SelectedDate 6   �� *
TaskDate+6?   �� 5,      $��1��6   $��2��6%   $��Time:��65   �� 5-      $��1��6   $��3��6'   $��5q�5.   J   ��6   �� *
TaskTime+ �� StringFormat$ hh\:mm��6J   �� 50      $��2��6   $��4��6*    �� Orientation$ 
Horizontal=�6>   $��Center=�6W   .+�51      �� $��Add Task��6   $��5q�6S   $	��100��6^   ��60   �� *AddTaskCommand+6^   �� 52      $��Update Task��6   $��5q�6Y   $	��100��6d   ��63   �� *UpdateTaskCommand+6d   �� 53      $��Delete Task��6   $��5q�6Y   $	��100��6d   ��63   �� *DeleteTaskCommand+6d   54      55      56      �� 59   
   $��1��6   $��	Task List��6    .��5:      �� ��6   �� *Tasks+ �� SelectedItem 65   �� *SelectedTask+��5;      �� 5<      .R�5=      �� 
�������$��1q�69   	 �� CornerRadius$	 5��6M   $��5q�6^   
 �� Padding$
 10q�6i   ._�5>      �  5?   "   �� 5@   &   $��* �67   �� 5A   &   $
��Auto �67   .+�5C   "   �� .+�5D   &   �� $
��Bold"�6F   $��14(�6X   ��60   �� *Name+6X   �� 5E   &   �� 5F   *   $�Due: ��6.    �� 5G   *   �6.   �� *Date+$ d�� �� 5H   *   $
� at ��6.    �� 5I   *   �6.   �� *Time+$ hh\:mm��5J   '   5K   #   �� 5L   "   $��1��6+   $��Center=�5M   +   $��Right=�6F    d� 	IsChecked 5L   ;   �� *IsCompleted+5M   F   5N      5O      5P      5R      5S      5T      5U      