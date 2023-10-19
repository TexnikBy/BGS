FROM node:18
WORKDIR /bgs-app
COPY ./client .

RUN npm install
RUN npm run build

ENV NODE_ENV production

EXPOSE 3000
CMD ["npm", "start"]