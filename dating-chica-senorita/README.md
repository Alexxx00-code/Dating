1 npm i
2 npm run build
3 запустить http (!именно http) web api на бек части
4 запустить ngrok для http чтобы сделать тунель для url которая хостится на https (установить отдельно ngrok https://ngrok.com/)
5 url полученная от ngrok подставить в телеграм бота в файле program в функции UpdateHandler и запустить его

ngrok config add-authtoken 2kkYybmYo9ICua1qAhVGHxJ0CV9_4bCJQeRrZsu4fmndZGa9t
ngrok http http://localhost:5249/

backend - c# net 8.0
frontend - angular 18
ui-component taiga ui
