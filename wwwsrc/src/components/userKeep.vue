<template>
    <div>
        <div class="card" style="width: 18rem;" v-for="keep in keeps" :key="keep.id">
            <img :src="keep.img"  class="card-img-top" alt="..." />
         <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <button class="btn btn-danger" @click="deleteKeep(keep.id)" v-show="keep.isPrivate == true">delete me</button>
        </div>
        </div> 
    </div>
</template>

<script>
export default {
name: "userKeep", 
data() {
    return {}
}, 
mounted() {
    this.$store.dispatch('getUserKeeps');
},
computed: {
    keeps() {
        return this.$store.state.keeps
        }
    }, 
methods: {
    deleteKeep(id){
        this.$store.dispatch("deleteKeep", id)
    }
}
}
</script>

<style scoped>
body {
  font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
  line-height: 1.6;
  background: #e8f7f0;
}
.container {
  max-width: 1100px;
  margin: auto;
  overflow: auto;
  padding: 0 2rem;
}
</style>
