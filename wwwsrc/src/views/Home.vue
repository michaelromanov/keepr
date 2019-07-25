<template>
  <div class="home container-fluid">
    <div class="row">
        <div class="col-12 mb3">
             <h1>Hello {{user.username}}, Welcome To The Friend Finder</h1>
             <button v-if="user.id" @click="logout">logout</button>
             <router-link v-else :to="{name: 'login'}">Login</router-link>
        </div>
        <user-keep /> 
        <new-keep />
        </div>
  </div>
</template>

<script>
    import userKeep from '@/components/userKeep.vue' 
    import newKeep from '@/components/newKeep.vue' 
    import publicKeep from '@/components/publicKeep.vue'
export default {
  name: "home",
  components: {
    userKeep, 
    newKeep,
    publicKeep
  },
  computed: {
    user() {
      return this.$store.state.user; 
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>


<!-- Reference Card: -->
 <!-- <div class="card" style="width: 18rem;" v-for="char in marioChar" :key="char.name">
      <img :src="char.img"  class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{char.name}}</h5>
        <p class="card-text"
        >{{char.description}}</p>
        <a:href="char.wiki" class="btn btn-primary">Wiki</a>
      </div>
    </div> -->

<!--
  data() {
    return {
      marioChar: [
        {
          name: "luigi",
          img: "https://upload.wikimedia.org/wikipedia/en/f/f1/LuigiNSMBW.png",
          description: "this is luigi",
          wiki: "https://en.wikipedia.org/wiki/Luigi"
        },
        {
          name: "mario",
          img:
            "https://upload.wikimedia.org/wikipedia/en/a/a9/MarioNSMBUDeluxe.png",
          description: "this is mario",
          wiki: "https://en.wikipedia.org/wiki/Mario"
        },
        {
          name: "peach",
          img:
            "https://upload.wikimedia.org/wikipedia/en/d/d5/Peach_%28Super_Mario_3D_World%29.png",
          description: "this is peach",
          wiki: "https://en.wikipedia.org/wiki/Princess_Peach"
        }
      ]
    };
  },>
  -->