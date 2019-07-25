<template>
    
</template>

<script>
export default {
name: "createkeep", 
data() {
    return {
        newkeep: {
            name: '', 
            decription: '', 
            img: ''
        }
    }
}, 
methods: {
    createkeep(){
        this.$store.dispatch(createkeep, this.newkeep)
    }
}
}
</script>

<style></style>
