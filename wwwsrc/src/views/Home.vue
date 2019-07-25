<template>
  <div class="home container-fluid">
    <div class="row">
        <div class="col-12 mb3">
             <h1>Hello {{user.username}}, Welcome To The Friend Finder</h1>
             <button v-if="user.id" @click="logout">logout</button>
             <router-link v-else :to="{name: 'login'}">Login</router-link>
        </div>
        <h3>
          My Private Friend(s) Keeps
        </h3>
        <user-keep /> 
        <new-keep />
        <h3>
          Public Keeps
        </h3>
        <public-keep />

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

<style scoped>

</style>