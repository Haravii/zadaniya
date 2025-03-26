import telebot
from telebot import types


bot = telebot.TeleBot('7918089588:AAFldhOgdsY9viv3bufShKNp6FZFlMnuX_0')

mainBtn1 = "Прокачка актуальных персонажей"
mainBtn2 = "Информация об актуальной версии Genshin Impact"

infoVer = "В Натлане проводить захватывающие соревнования - это всегда замечательно.\nНо организовать такое грандиозное состязание, которое объединит все шесть племён? Поистине незабываемое событие!\nИ вот люди с заврианами вновь мчатся по этой древней земле, совсем как бесчисленное множество раз сотни и тысячи лет назад.\nДух соперничества, как и пламя Натлана, вечен."

picBtn1 = "Покажи что нужно для прокачки Варесы"
picBtn2 = "Покажи что нужно для прокачки Сянь Юнь"
picBtn3 = "Покажи что нужно для прокачки Иансан"


@bot.message_handler(commands=['start'])
def send_welcome(message):
    show_main_menu(message)


@bot.message_handler(func=lambda message: True)
def handle_message(message):
    if message.text == mainBtn1:
        show_picture_buttons(message)
    elif message.text == mainBtn2:
        show_article_buttons(message)
    elif message.text in [picBtn1, picBtn2, picBtn3]:
        send_cat_picture(message, message.text)
    elif message.text == "Назад":
        show_main_menu(message)
    else:
        bot.send_message(message.chat.id, "Не пон, это ты щас оскорбил Кли??")



def show_main_menu(message):
    keyboard = types.ReplyKeyboardMarkup(row_width=1, resize_keyboard=True)
    button_picture = types.KeyboardButton(mainBtn1)
    button_article = types.KeyboardButton(mainBtn2)
    keyboard.add(button_picture, button_article)
    bot.send_message(message.chat.id, "Вы нажали /start, а Вы умнее, чем я думал. Чем могу помочь?", reply_markup=keyboard)


def show_picture_buttons(message):
    keyboard = types.ReplyKeyboardMarkup(row_width=1, resize_keyboard=True)
    button_1 = types.KeyboardButton(picBtn1)
    button_2 = types.KeyboardButton(picBtn2)
    button_3 = types.KeyboardButton(picBtn3)
    back_button = types.KeyboardButton("Назад")
    keyboard.add(button_1, button_2, button_3, back_button)
    bot.send_message(message.chat.id, "Выберите карточку:", reply_markup=keyboard)

def show_article_buttons(message):
    keyboard = types.ReplyKeyboardMarkup(row_width=1, resize_keyboard=True)
    bot.send_message(message.chat.id, infoVer, reply_markup=keyboard)

def send_cat_picture(message, cat_type):
    if cat_type == picBtn1:
        picture_url = "https://genshindrop.io/storage/image/1742958779-vkmhxxxmggsfn6qq.webp"
    elif cat_type == picBtn2:
        picture_url = "https://sun1-19.userapi.com/impg/SrUWYNBSKn0Jza16R7SHZfVEJ4qGkyxCTHsFmQ/8hbKqFHLKL4.jpg?size=604x604&quality=96&sign=fe6acf3b3e0677ad2f430647b10c2bfd&type=album"
    else:
        picture_url = "https://genshindrop.io/storage/image/1742960327-wdklecqeghpgwel9.webp"

    bot.send_photo(message.chat.id, picture_url, caption=cat_type)

bot.infinity_polling()
