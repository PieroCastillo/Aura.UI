# Avalonia Ripple Effect

[![N|Solid](https://i.imgur.com/SJo17KT.gif)](https://i.imgur.com/SJo17KT.gif)

Sample of ripple effect using Avalonia. 
All things which wrapped in RippleEffect will be effected

```sh
<RippleEffect Width="200"
              Height="60"
              RippleFill="#F1F2F2"
              RippleOpacity="0.2">
    <Border Background="#212121"
            CornerRadius="3">
      <TextBlock HorizontalAlignment="Center"
                 VerticalAlignment="Center"
                 FontSize="20"
                 Foreground="#E6E7E8"
                 Text="RIPPLE" />
    </Border>
  </RippleEffect>
```
