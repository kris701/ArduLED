![Error Loading Image](https://0apetq.db.files.1drv.com/y4m6XD4Km6TCergU4jwpiIzx3m6tbE5BFe25eHyLf_hLCbKXqCfZlCS8aKucGG23JEL4dY5NuVNMtxb820mWAgJjQCEYtfOarZcaQVj1Tmc_gIql95YVL4RSBXXsFSmM-64xZnvvbnKtWhRpF7_cP5-xaV0RPduygApRX3ncA90FD8uhR6lTd7K2hKYwbg4mYypUFaO6B4Gkubf6CWQTCgYug/toplabel.gif?psid=1?width=150&height=85&cropmode=none)

### This project is work in progress, expect errors and mistakes

Welcome, to the ArduLED project. What is this? you may ask, this is a program, both one for an Arduino and one for a computer, together makes it posable to control Neopixels (ws2812b). It features easy-to-do setup, that does not require much work. A list of features can be made:
 
 - Supports up to 8 LED strips with a total of over 200 LEDs (Testet up to 200, can go higher)
 - Dynamic setup from the computer, there is no need to change the code for the Arduino if changes to your setup are made
 - [BASS.NET](http://bass.radio42.com/) powered visualizer, with a lot of diffrent options (Very fast, ~100 RPS on 135 LEDs on Beat Wave)
 - Fading colors
 - Instructions mode, setup a set of instructions that the LED will follow
 - Ambilight feature (~20 15-20 FPS on 4k screen with 50 LEDs)
 - Very easy to use
 - Supports multiple languages
 - Includes a local Server API, to control ArduLED from your own programs
 
 <p align="center">
 <img src ="https://2ar6kq.db.files.1drv.com/y4mJmTUzQuhQ4HxCBJNVtMBwT4NKl8VFImfG7AsaESwZP0f_hF35M6pKuxWg305abgShxsAMfI9yA5U_Zxwdb02-Lv4Qw2RrMvXbWi7-sVv95W24ukcjd89boB_wVU-Kk49aUmesvZj1imHzRILTWueeKcXuPN7TXhJdMNhbAtZItQtrW31V0_V5QIIAcOKITuXrHLD4pUmmWSg4FaaMP8rAg/fadecolorssample_reduced_optim_small.gif?psid=1?width=150&height=85&cropmode=none" />
 <img src ="https://2ar5kq.db.files.1drv.com/y4m_WcbV3auLJoFqobeJmR9yHAKosaUjoMYTEplHlzmzpq1T3YFsCAFF9uzqnJlGieosuVGNqHkzhvzvSUGbBpfaTPe-bSrZdOI46SNZePdtUhh5-xNPHo4YhinNzAdya1662vYdM6Yp2FbhXMkcBtc6FlsWWx2FXSrku3rMhMxYhq10N8Gz07-WgZ34NQGHnHxZ9u6kvafIEITlBi-Q3ni9w/frontpage1optim3_small.gif?psid=1?width=150&height=85&cropmode=none" />
 <img src ="https://2aoakg.db.files.1drv.com/y4mwdnTstudEaDWpOh83IFs5ps4YEP4BdQS44t18iOj_K9ClkX7yb3yfeoiJZvc58S3IRhNl8K0X9ukPYX5vsAKYnjiZk1Jl3rg2Rwu4fi0N7WPiupCubHmkjfyOupqA4CHs0tDDVs9m1dXOnTYmaWiMT6xdmlFB6eanDifn6g8WtIce0zcjT1tdyXbS0XMmVdVFqZuOM4jRjCJR-FTlPIbvg/frontpage2optim3_small.gif?psid=1?width=150&height=85&cropmode=none" />
</p>

<p align="center">
 <img src ="https://2arqkq.db.files.1drv.com/y4mgGNW9fY8QQKi-0mBn95TAdc9kUyH59Bo2Ynyq40UCmKNPQYizjxeyGLQ8YIc7OdOBW9h5_4yJJeEOXU7QdOiFaRqmLGgFxrFK98asBvhFd5kiNLExmbl1ReAQgHkn4l9_JQH45Vw0BNK74NVNLlWAnuJjnLyEIKAHjjNQGqT99Qb05cw-cPB4xY6K5gZ15DVaNEWrHmuYaZRKFvBEnwe_g/instructionsmodesample_reduced_optimized_small.gif?psid=1?width=150&height=85&cropmode=none" />
 <img src ="https://2arpkq.db.files.1drv.com/y4mfJmHhrDyUFmoFj0mLxfFECjcdlosWhyjROz3GmrTMF09SMTNS4nbsRb73R6-h8D17IIEfXVl8rTByLXvED4Hmhk9L4csrDWWgQhGYVOV7uGF1gG8kz7JhWHogoXbSewCCFa-K93MleFFg59N9VrU5pv6K4m3zxM4CETrVhxRoUhNZsV33UMyl0aWpA-U4wWPT9XXH-w2Ayym_Mj5yL0xLw/ledwavesample_reduced_optim_small.gif?psid=1?width=150&height=85&cropmode=none" />
 <img src ="https://2ar9kq.db.files.1drv.com/y4mRztNZ3PxFrJZz3fyx69tSAS_llMYBC9gNFljFi-c2BNN3EiHoNrzMuG3CIdlYV230o6RHScsLOF2EpuQJEcwJjUyKM9QZxUTJ407PL3rUxJtkVybieXf0di9j8jjbkW7fFXofNbW-4ioI5T2yyQJCx8URBgKc-nzOUOP2KQ0FgJg8KMyBmlNEO3kYH03QGHUlQ2XZLW6BMCFyv9pzAWS6A/visualizersample_reduced_optim_small.gif?psid=1?width=150&height=85&cropmode=none" />
</p>

And this is only the main topics of what ArduLED can do. There is still a lot of smaller features, however those are for you to find :)

This project is open source, so all the Visual Studio files comes with the project. From there on, you can either just use the program itself, or look into how its made.

![Error Loading Image](https://0apltq.db.files.1drv.com/y4mUFqSsSeJb_r6ybSDBTl_l2rx1dJU-R7R852YPt6aXdiJXMWdphZl5YtKKNJLNDXYGT1yuFbR1HjB-U8MHjwX97KGqcjIQolq426uJO7MgLIOFQy1_2JKPAt3xkpV8n5xyrwueGhTU7XPSwIyC18Ox_FwSXzB2cWyhb8Y9OH3pmzZ9DvYsvlwkMqiUWmIZoY7qT4_HzS4wao5bL9tPKBBGg/howtouselabel.gif?psid=1?width=150&height=85&cropmode=none)

- [**Home**](https://github.com/kris701/ArduLED/wiki)
- [**Requirements and Setup**](https://github.com/kris701/ArduLED/wiki/Requirements-and-setup)
- [**First Startup**](https://github.com/kris701/ArduLED/wiki/First-Startup)
- **How to use**
  - [Main Menu](https://github.com/kris701/ArduLED/wiki/Main-Menu)
  - [Fade Colors](https://github.com/kris701/ArduLED/wiki/Fade-Colors)
  - [The Visualizer](https://github.com/kris701/ArduLED/wiki/The-Visualizer)
  - [Individual LED Control](https://github.com/kris701/ArduLED/wiki/Individual-LED-Control)
  - [Instructions Mode](https://github.com/kris701/ArduLED/wiki/Instructions-Mode)
  - [Ambilight Mode](https://github.com/kris701/ArduLED/wiki/Ambilight-Mode)
  - [Configure Setup](https://github.com/kris701/ArduLED/wiki/Configure-Setup)

Feel free to support us via patreon: https://www.patreon.com/ArduLed I means alot! 
