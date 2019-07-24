<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <!-- <div class="card" style="width: 18rem;" v-for="char in marioChar" :key="char.name">
      <img :src="char.img"  class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{char.name}}</h5>
        <p class="card-text"
        >{{char.description}}</p>
        <a
          :href="char.wiki"
          class="btn btn-primary" 
        >Wiki</a>
      </div>
    </div> -->

      <div class="card" style="width: 18rem;" v-for="char in marioChar" :key="char.name">
      <img :src="char.img"  class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{char.name}}</h5>
        <p class="card-text"
        >{{char.description}}</p>
        <a
          :href="char.wiki"
          class="btn btn-primary"
        >Wiki</a>
      </div>
    </div>

  </div>
</template>

<script>
    //import all keeps from components?

export default {
  name: "home",
  // data() {
  //   return {
  //     marioChar: [
  //       {
  //         name: "luigi",
  //         img: "https://upload.wikimedia.org/wikipedia/en/f/f1/LuigiNSMBW.png",
  //         description: "this is luigi",
  //         wiki: "https://en.wikipedia.org/wiki/Luigi"
  //       },
  //       {
  //         name: "mario",
  //         img:
  //           "https://upload.wikimedia.org/wikipedia/en/a/a9/MarioNSMBUDeluxe.png",
  //         description: "this is mario",
  //         wiki: "https://en.wikipedia.org/wiki/Mario"
  //       },
  //       {
  //         name: "peach",
  //         img:
  //           "https://upload.wikimedia.org/wikipedia/en/d/d5/Peach_%28Super_Mario_3D_World%29.png",
  //         description: "this is peach",
  //         wiki: "https://en.wikipedia.org/wiki/Princess_Peach"
  //       }
  //     ]
  //   };
  // },
  data(){

  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  mounted() {
this.$store.dispatch('getKeeps');
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>